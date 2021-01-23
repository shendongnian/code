    public interface IFooWrapper {
      event EventHandler<EventArgs> Bar;
      string Message { get; set; }
      void RunBar();
    }
