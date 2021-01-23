    public class AjaxResult : ActionResult
    {
        public object Data { get; set; }
    
        public bool Completed { get; set; }
    
        public string Message { get; set; }
    
        public bool AllowGet { get; set; }
    
        public override void ExecuteResult(ControllerContext context)
        {
    
            var result = new JsonResult
            {
                Data = new
                {
                    Completed = this.Completed,
                    Message = this.Message,
                    Data = this.Data
                }
            };
            result.JsonRequestBehavior = this.AllowGet ? JsonRequestBehavior.AllowGet : JsonRequestBehavior.DenyGet;
            result.ExecuteResult(context);
        }
    }
