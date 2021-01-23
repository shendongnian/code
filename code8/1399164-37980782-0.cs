    public interface IMyAttribute<T>
    {
      int Id { get; set; }
      T Value { get; set; }
    
      bool IsValid();
    }
