    public class SampleClass{
        public string Message {set; get;}
    }
    
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public PassWordClass Auth(string username)
    {
       
            return new SampleClass(){
    	    Message  = "Sample message"
    	};
    
    }
