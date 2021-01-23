    public class AppSettings 
    { 
     public string Environment
     { 
     get 
     { 
      return new Configuration().Get("AppSettings:Environment").ToString(); 
     }
     set; 
     } 
    }
