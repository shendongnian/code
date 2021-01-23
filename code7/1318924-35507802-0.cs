    class ObjType
    {
       private string _message;
    
       // look at _this_ being called before executing constructor body
       public ObjType() :this("hello")
       {}
    
       private ObjType(string message)
       {
           _message = message;
       }
    }
  
