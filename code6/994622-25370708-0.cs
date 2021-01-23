    // assembly: Production.dll (no dependencies)
    namespace Production {
      public class Test {
        public void Do() {
          Console.Out.WriteLine("Production");
        }
      }
    }
    // assembly: Simulation.dll (no dependencies)
    namespace Production {
      public class Test {
        public void Do() {
          Console.Out.WriteLine("Simulation");
        }
      }
    }
    // assembly: Usage.dll (dependency on Production.dll)
    namespace Usage {
      public class TestUsage {
        public void Do() {
          new Production.Test().Do();
        }
      }
    }
