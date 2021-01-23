    public class SomeEntity
    {
      private bool _field
      public bool? Field
      {
        get { return _field; }
        set { _field = value.HasValue ? false : value.Value; }
      }
    }
