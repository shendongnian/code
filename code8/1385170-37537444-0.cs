    public interface Interface<T> where T : BaseClass
    {
        T method();
    }
    
    public class DrivedClass: BaseClass,Interface<DerivedClass>
    {
      public DerivedClass method()
      {
          DerivedClass derviedObj = Builder<DrivedClass>.CreateNew().Build();
          return derviedObj ;
      }
    }
