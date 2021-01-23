    public class BaseClass
    {
    }
    public class Sub_BaseClass<T> : BaseClass
    {
    }
    ...
    public void DoSomething<T>(BaseClass objct)
    {
      Sub_BaseClass<T> variable;
      variable = objct as Sub_BaseClass<T>;
      ...
    }
