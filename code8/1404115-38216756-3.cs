    //json container
	public class AjaxMessageContainer<T>
    {        
        [JsonProperty(PropertyName = "result")]
        public T Result { set; get; }
    }
    //your own actionresult
	public class AjaxResult<T> : ActionResult
    {        
        private readonly T _result;                      
        public AjaxResult(T result)
        {          
            _result = result;           
        }
        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(new AjaxMessageContainer<T>
            {               
                Result = _result,               
            });
            var bytes =
                new UTF8Encoding().GetBytes(result);
            context.HttpContext.Response.OutputStream.Write(bytes, 0, bytes.Length);           
        }
    }
    //your controller
    [JSONAPIFilter]
    public AjaxResult<List<String>> TestSimple()
    {
        return AjaxResult<List<String>>(new List<string>() { "hello", "world" });
    }
