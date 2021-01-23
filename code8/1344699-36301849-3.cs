    public class SampleClass{
        public string Message {set; get;}
    }
    
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public SampleClass BarcodeEntered()
    {
       
            return new SampleClass(){
    	    Message  = "Sample message"
    	};
    
    }
