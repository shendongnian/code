    public class MyClass{
      private void methodA(){
        int varA;
        varA = GetSingleValesFromDB();
        .......
      }
      private void methodB(){
        DoSomething(varA);
        .......
      }
      public void methodC(){
        methodA();
        methodB();
      }
    }
