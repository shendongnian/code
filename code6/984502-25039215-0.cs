    public JsonResult CheckTimeout()
    {
        return Json(new JsonReturn { Success = true, ResponseData = new object() });
    }
    [Serializable]
    public class JsonReturn : JsonResult
    {
        public JsonReturn()
        {
            Success = true;
            Message = string.Empty;
            ResponseData = null;
        }
    
        public JsonReturn(object obj)
        {
            Success = true;
            Message = string.Empty;
            ResponseData = obj;
        }
    
            public bool Success { get; set; }
            public string Message { get; set; }
            public object ResponseData { get; set; }        
        }
    }
