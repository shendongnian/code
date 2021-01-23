    public class Object1 {
        public int number{get;set;}
    }
    public class Object2 {
        public int number{get;set;} 
    }
    
    public class Object3 {
        public int number{get;set;} 
    }
    
    main();
    
    public void main(){
        var objects1 = new List<Object1>{new Object1{number=1} , new Object1{number=2}};
         test<Object1>(objects1);
    }
    
    
    public List<Object3> test<T>(IEnumerable<T> objs){
        var rv = new List<Object3>();
        
        foreach (var o in objs)
        {
            if(typeof(T) == typeof(Object1)){
                rv.Add(overloaded((Object1)(object)o));
            } else {
                rv.Add(overloaded((Object2)(object)o));
            }
        }
        
        return rv;
    }
        
                
    public Object3 overloaded(Object1 obj){
        return new Object3{number=obj.number+1}; 
    }
    
    public Object3 overloaded(Object2 obj){
        return new Object3{number=obj.number+2};    
    }
