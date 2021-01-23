    //The method makes use of Generics and C# Action delegates.  To Use it. You need to have the following
    
    public class MyContext : DbContext
    {
      //MyContext implementation here
    }
    
    class Program
    {   
        public static void MyRetryActionMethod(MyContext mycontext)
        {
           //Some implementation here
        }
        
        //Use the Method e.g
        
        static void Main()
        {
           var mycontext = new MyContext();
    
           //This is how you will call the method
           MyRetryActionMethod = (mycontext ) => { //Do Stuff };
           Retry<MyContext>(MyRetryActionMethod);
           
           //Alternatively use lambda
    
           Retry<MyContext>((mycontext) => { 
               
               //Do stuff here
            });
        }
    }
    
    //And it simply means is, you can pass a method with that signature to the method.
