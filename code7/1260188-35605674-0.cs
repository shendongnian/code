    public class BadRequestResult : HttpStatusCodeResult
    {
        private readonly string _reason;
        public BadRequestResult(string reason) : base(400)
        {
            _reason = reason;
        }
        public override void ExecuteResult(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = _reason;
            context.HttpContext.Response.StatusCode = StatusCode;
        }
    }
