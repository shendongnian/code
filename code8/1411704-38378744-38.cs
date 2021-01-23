    public class CodesResult : ActionResult
    {
        private readonly List<Codes> _list;
        public CodesResult(List<Codes> list)
        {
            this._list = list;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            var response = context.HttpContext.Response;
            response.ContentType = "text/plain";
            if (this._list != null)
            {
                // You still have to define serialization
                var text = string.Join(",", this._list.Select(x => string.Format("[{0},{1}]", x.hr, x.ps)));
                response.Write(text);
            }
        }
    }
