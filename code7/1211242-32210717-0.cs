    public class StaticInterop
    {
      public static event EventHandler ButtonClicked;
    
      public static void FireButtonClicked()
      {
        if (ButtonClicked != null)
        {
          ButtonClicked(null, null);
        }
      }
    }
