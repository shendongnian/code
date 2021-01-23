    public class MyUserControl : UserControl
    {
      public void MyUCMethod()
      {
      }
    }
    
    public class MyClass
    {
      private MyUserControl myUC;
      public MyClass(MyUserControl uc)
      {
        myUC = uc;
      }
      public void MyClassMethod()
      {
        myUC.MyUCMethod();
      }
    }
    
