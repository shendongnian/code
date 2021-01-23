    [Loggable]
    internal class Program {
        private static void Main(string[] args) {
            String[] myArray = new String[] {"X"};
            for (int i = 0; i <= 100; i++) {
                Console.WriteLine(myArray[i]);
            }
        }
    }
    [Serializable]
    public class LoggableAttribute : OnExceptionAspect {
        public override void OnException(MethodExecutionArgs args) {
            Console.WriteLine("Caught by postsharp: " + args.Exception);
            args.FlowBehavior = FlowBehavior.Continue;
        }
    }
