    public class ColorSet {
      private Color red;
      private Color green;
      private Color blue;
      protected ColorSet(Type type) {
        red = (Color)Activator.CreateType(type);
        red.Name = Values.Res.get("red");
        green = (Color)Activator.CreateType(type);
        green.Name = Values.Res.get("red");
        blue = (Color)Activator.CreateType(type);
        blue.Name = Values.Res.get("red");
      }
      public static ColorSet FromType<T>() where T : Color {
        return new ColorSet(typeof(T));
      }
    }
