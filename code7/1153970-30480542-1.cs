            var httpContext =
                new HttpContextWrapper(
                    new HttpContext(
                        new HttpRequest(null, "http://servername/api/diagnostic/get", // interestingly the actual servername is not required.
                            "parameter=1&parameter2=foo"),
                        new HttpResponse(new StringWriter())));
            var routeData = RouteTable.Routes.GetRouteData(httpContext);
            var req = new RequestContext(httpContext, routeData);
            var controller =
                (ControllerBase)
                    ControllerBuilder.Current.GetControllerFactory()
                        .CreateController(new RequestContext(httpContext, routeData), routeData.Values["controller"].ToString());
            var context = new ControllerContext(req, controller);
            controller.ControllerContext = context;
            var desc = new ReflectedControllerDescriptor(controller.GetType());
            var action = desc.FindAction(context, routeData.Values["action"].ToString());
            var queryString = httpContext.Request.QueryString;
            var parameters = action.GetParameters()
                .ToDictionary(p => p.ParameterName,
                    p =>
                        p.ParameterType.IsEnum
                            ? Enum.ToObject(p.ParameterType, Convert.ChangeType(queryString.GetValues(p.ParameterName)[0], TypeCode.Int32))
                            : Convert.ChangeType(queryString.GetValues(p.ParameterName)[0], p.ParameterType));
            var result = action.Execute(context, parameters);
