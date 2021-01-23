        public class CssViewResult : PartialViewResult
        {
            private readonly object model;
            public CssViewResult(object model)
            {
                this.model = model;
            }
            public override void ExecuteResult(ControllerContext context)
            {
                // Do something with this.model
                context.HttpContext.Response.ContentType = "text/css";
                base.ExecuteResult(context);
            }
        }
