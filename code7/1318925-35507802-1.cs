    class BaseType 
    {
       private string _message;
       
       // should be at least protected
       protected BaseType(string message)
       {
           _message = message;
       }
    }
    
    class ObjType : BaseType
    {
       // look at _base_ being called before executing constructor body
       public ObjType() :base("hello")
       {}
    }
