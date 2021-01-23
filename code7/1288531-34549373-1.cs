    public interface IView{}
    public abstract Presenter<T> where T : IView
    {
      public Presenter( T view){ View = view;}
      public T View {get;set;}
    }
