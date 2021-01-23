    public interface IMyAttribute<T>
    {
      int Id { get; set; }
      T Value { get; set; }
    
      bool IsValid();
    }
    public IMyData<TData, TValue> where TData : IMyAttribute<TValue>
    {
      List<TData> data { get; set; };
    
      void SetProperties();
      bool IsValid();
    }
    public class MyLegacyData<TData, TValue> : IMyData<TData, TValue>
        where TData : IMyAttribute<TValue>
    {
      ...
      List<TData> data { get; set; }
      ...
    }
