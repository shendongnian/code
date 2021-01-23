    abstract class AbstractClass
    {
     public abstract void AbstractMethodA();
     public void ConcreteMethodA()
     {
      //Some operation
      Helper.ConcreteMethodB(this);
     }
    }
