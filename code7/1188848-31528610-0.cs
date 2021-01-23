    public class Object1 {
        public int number{get;set;}
    }
    public class Object2 {
        public int number{get;set;} 
    }
    main();
    public void main(){
         var o1 = new Object1{number=1};
         test<Object1>(o1);
    }
    public void test<T>(T obj){
        //do a bunch of stuff that both Object1 and Object2 have in common
        // ...
        //
        
        // Now attempt to do stuff thats specific to each object
        if(typeof(T) == typeof(Object1)) {
            overloaded((Object1)(object)obj);
        }
        
    }
    public void overloaded(Object1 obj){
        Console.WriteLine("Do Object 1 stuff");   
    }
    public void overloaded(Object2 obj){
        Console.WriteLine("Do Object 2 stuff");   
    }
