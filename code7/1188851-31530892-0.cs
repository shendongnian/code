    interface IObject 
    {
       int number {get;set;}
    }
    public class Object1 : IObject {
        public int number{get;set;}
    }
    public class Object2 : IObject  {
        public int number{get;set;} 
    }
    
    public class Object3 : IObject  {
        public int number{get;set;} 
    }
    public IObject overloaded(IObject obj){
        // Run very specific things to Object1
        return new IObject {number=obj.number+1}; 
    }
