        public static string RenderRazorViewToString(string viewToRender, object model, string controllerName, string loadAction, HttpContextBase httpContext, List<FormViewBags> viewData, string formModelType)
        {
            string view = "";
            //Creating the view data
            ViewDataDictionary ViewData = new ViewDataDictionary();
            //The type of model used for this view
            Type modelType = Helper.GetModelType(formModelType); 
            //Compiling the object model from parameter with the correct type
            ViewData.Model = Cast(model, modelType);
            if ((ViewData.Model != null) && (viewData != null))
            {
                //Adding view bags for the view
                foreach (FormViewBags item in viewData)
                {
                    ViewData.Add(item.Key, item.Value);
                }
            }
            //The controller used to all this view
            Type controllerType = Helper.GetModelType(controllerName);
            //Creating the controller
            object controller = Activator.CreateInstance(controllerType);
            //Setting the routing
            RouteData rd = new System.Web.Routing.RouteData();
            rd.Values.Add("controller", controllerName.Split('.').Last().Replace("Controller",""));
            //rd.Values.Add("action", loadAction);
            //Setting the controller with corresponding context
            ((ControllerBase)(controller)).ControllerContext = new ControllerContext(httpContext, rd, (ControllerBase)controller);
            ControllerContext cc = ((ControllerBase)(controller)).ControllerContext;
            using (var sw = new StringWriter())
            {
                //The custom view engine I used to get the view
                var engine = ViewEngines.Engines.Where(s => s.ToString().Equals("MyApp.App_Start.CustomViewEngine")).SingleOrDefault();
                if (engine == null) throw new Exception("no viewengine");
                
                //Finding the string/text of the view. My website use VPP to get view from database.
                var viewResult = engine.FindPartialView(cc, viewToRender, false);
                var viewContext = new ViewContext(cc, viewResult.View, ViewData, cc.Controller.TempData, sw);
                //This code here renders all the information above into the real compiled string view
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(cc, viewResult.View);
                view = sw.GetStringBuilder().ToString();
            }
            //Returns the string of the compiled view
            return view;
        }
