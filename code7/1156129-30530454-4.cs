    static class Helper {
     public static void ConcreteMethodB(IAbstractClass caller)
     {
          //Huge code unrelated to this class
          caller.AbstractMethodA();
     }
    }
    interface IAbstractClass {
         void AbstractMethodA();
    }
