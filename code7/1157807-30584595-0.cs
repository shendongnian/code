    // This is a Class definition
    public class Class1 {
     public string SETMax {get; set;}
     public int MaxValue {get; set;}
    }
    
    
    // This is your application
    public class MyApp{
    
     // this is a private field where you will assign an instance of Class1
     private Class1 class1Instance ;
    
     public MyApp(){
       //assign the instance in the constructor
            class1Instance = new Class1();
     }
    
     public void Run {
      // now for some fun
    
       class1Instance.SETMax = "Hello";
       Console.WriteLine(class1Instance.SETMax); // outputs "Hello"
       var localInstance = new Class1();
       localInstance.SETMax = class1Instance.SETMax;
       Console.WriteLine(localInstance.SETMax); // outputs "Hello"
    }
     }
    
     
