    public class MyInheritedClass :IMyBaseClass
    {
        public string MyVar1 {get;set;}
        public string MyVar2 {get;set;}
        public string MyVar3 {get;set;}
        public MyInheritedClass() 
        {
             this.MyVar1 = "whatever";
             this.MyVar2 = "something";
             this.MyVar3 = "something else";
        }
        public bool MyFunc()
        {
           // do some code here
        }
    }
Notice I didn't have to write override on the properties, because if your class is inheriting from an Interface, then you can implement your own implementation per class. Just like an abstract class, an interface cannot be used as an object.
