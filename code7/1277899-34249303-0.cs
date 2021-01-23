    public class HydroElectric
    {
      //.... Your other code
      //....
      public static bool T1Bool {
        get{
          return t1Bool;
        }
        set{
          t1Bool = value;
          if (t1Bool == true)
          {
            turbina1 = 2;
          }
          else
          {
            turbina1 =0;
          }
      
          prod = turbina1;
        }
      }
    }
    
    //...
    // Usage
    HydroElectric.T1Bool = GUI.Toggle (new Rect (25, 55, 100, 50), HydroElectric.T1Bool, "Turbina 2 MW");
