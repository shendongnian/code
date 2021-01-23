    public interface MyInterface<T,TCollection>
    where TCollection : ICollection<T>
    {
      TCollection MyCollection{ get; set; }
    }
