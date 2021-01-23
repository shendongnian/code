    public IMyData<T> where T : IMyAttribute
    {
      List<T> data { get; set; };
    
      void SetProperties();
      bool IsValid();
    }
    public class MyLegacyData<T> : IMyData<T> where T : IMyAttribute
    {
      ...
      List<T> data { get; set; }
      ...
    }
