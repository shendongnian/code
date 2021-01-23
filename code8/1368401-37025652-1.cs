    public class MyClass{
      private void methodA(){
        int varA;
        varA = GetSingleValesFromDB();
        .......
      }
      private void methodB(){
        int varA;
        varA = GetSingleValesFromDB();
        DoSomething(varA);
        .......
      }
      public void methodC(){
        methodA();
        methodB();
      }
    }
