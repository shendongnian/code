    public class MyClass {
       private string _cont;
       public MyClass(string cont) { _cont = cont; }
       public override string ToString() { return _cont; }
    }
    MyClass c1 = new MyClass("abc");
    MyClass c2 = c1;
    c2 = new MyClass("123");
    Debug.Log(c1.ToString() + ":" + c2.ToString());
