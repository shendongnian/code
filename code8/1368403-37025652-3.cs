    public class MyClass{
      private class MyMethodState
      {
        public int varA;
      }
      private void methodA(MyMethodState state){
        state.varA = GetSingleValesFromDB();
        .......
      }
      private void methodB(MyMethodState state){
        DoSomething(state.varA);
        .......
      }
      public void methodC(){
        var state = new MyMethodState();
        methodA(state);
        methodB(state);
      }
    }
