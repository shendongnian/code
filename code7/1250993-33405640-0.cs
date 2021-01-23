    class NewMyClass {
      private static Func<MyClass> create = null;
	  public class MyClass {
	    public static void Init() { NewMyClass.create = ()=> new MyClass();}
        private MyClass(){ }
        public string Name { get; set; }
      }
	  public MyClass Method(){
        MyClass.Init(); 
	   	MyClass cls = create();
       	cls.Name = "My Name";
	    return cls;
	  }
    } 
