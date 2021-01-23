    namespace Simulation {
      internal class Doable : IDoable {
        public void Do() { Console.Out.WriteLine("Simulation"); }
      }
      public static class Bootstrapper {
        static void Init(IServiceLocator locator) {
          locator.AddSingleton<IDoable, Doable>();
        }
      }
    }
