    public partial class AjaxResult : ActionResult
    {
        public AjaxResult()
        {
            this.StatusCode = 200;
        }
    
        public virtual int StatusCode { get; set; }
    
        public virtual object Data { get; set; }
    
        public virtual bool Completed { get; set; }
    
        public virtual string Message { get; set; }
    
        public virtual bool AllowGet { get; set; }
    
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
    
            if (!this.AllowGet && String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("Ajax GET request not allowed.");
            object responseData = new
            {
                Completed = this.Completed,
                Message = this.Message,
                Data = this.Data
            };
            HttpResponseBase response = context.HttpContext.Response;
            response.Clear();
            response.ContentType = "application/json";
            response.StatusCode = this.StatusCode;
            response.Write(JsonConvert.SerializeObject(responseData));
    
        }
    }
