        public override async Task OnActionExecutingAsync(HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            var argumentKey = actionContext.ActionArguments.FirstOrDefault().Key;
            var owinContext = (OwinContext) actionContext.Request.Properties["MS_OwinContext"];
            owinContext.Request.Body.Seek(0, SeekOrigin.Begin);
            var source = await actionContext.Request.Content.ReadAsAsync(_sourceType, cancellationToken);
            actionContext.ActionArguments[argumentKey] = Mapper.Map(source, _sourceType, _destType);
            await base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
