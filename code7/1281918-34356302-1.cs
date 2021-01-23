     public class MyThing : SomeBaseClass, ICanImplementInterfaces
     {
         private Lazy<MyThing> myThingLazy = new Lazy<MyThing>(() => new MyThing())
         public static MyThing Instance
         {
             get
             {
                 return myThingLazy.Value;
             }
         }
     }
