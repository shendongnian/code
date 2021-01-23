    public class PreventGen0Collection
    {
      private object _keptAlive;
      public PreventGen0Collection(object keptAlive)
      {
        _keptAlive = keptAlive;
      }
      ~PreventGen0Collection()
      {
      }
    }
