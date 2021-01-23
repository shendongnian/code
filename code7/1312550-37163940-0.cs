        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(TokenExpiredException))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Exception = null;
            }
            base.OnException(context);
        }
