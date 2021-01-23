    namespace Production {
      internal class Doable : IDoable {
        public void Do() { Console.Out.WriteLine("Production"); }
      }
      public static class Bootstrapper {
        static void Init(IServiceLocator locator) {
          locator.AddSingleton<IDoable, Doable>();
        }
      }
    }
