    abstract class A {
       public string Prop1 { get; set; }
       public string Prop2 { get; set; }
       protected abstract void LoadData();
       public A() {
          //some code
          LoadData();
          //some code
       }
    }
