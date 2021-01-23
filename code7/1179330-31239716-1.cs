    class BaseNonAbstract
    {
          public virtual string Meth1()
          {
             // do something
             return string.Empty;
          }
    }
    abstract class ChildAbstract : BaseNonAbstract
    {
        public abstract override string Meth1();
    }
