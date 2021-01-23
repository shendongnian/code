    public class ReadIntro {
      private Object _obj = new Object();
      void PrintObj() {
        Object obj = _obj;
        if (obj != null) {
          Console.WriteLine(obj.ToString());
        // May throw a NullReferenceException
        }
      }
      void Uninitialize() {
        _obj = null;
      }
    }
