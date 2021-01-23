    public class MyClass{
      private int varA;
      private void methodA(){
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
