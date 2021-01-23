      public class MyClass
    {
        public string status { get; set; }
        public string MyAction() {
        try {
            
           return status = "OK";
        }
        catch (Exception ex)
        {
            //throw ex;
           return status = ex.InnerException.ToString();
        }
    }
    }
