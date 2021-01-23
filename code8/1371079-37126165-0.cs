    namespace ConsoleApplication6 {
    public class Context
    {
        public Command CommandList { get; set; }
        public Processor Processor { get; set; }
    }
    public class Processor
    {
        public void ExecuteSimpleCommand(Command command)
        {
        }
        public void ExecuteComplexCommand(Command command) {
        }
    }
    public enum CommandType
    {
        Simple,
        Complex
    }
    public class Command {
        public CommandType Type { get; set; }
        public Command Next { get; set; }
        public object Data { get; set; }
    }
    class Program
    {
        private readonly object signalObject = new object();
        private object computationResult;
        private int sharedPriority = -1;
        static void Main(string[] args) {
        }
        private void ThreadFunc(object state) {
            Context ctx = (Context)state;
            Command cmd = ctx.CommandList;
            Processor proc = ctx.Processor;
            while (cmd != null) {
                switch (cmd.Type) {
                    case CommandType.Simple:
                        proc.ExecuteSimpleCommand(cmd);
                        break;
                    case CommandType.Complex:
                        //each thread will atomically increment the sharedPriority; only the thread with priority=0 (we start from -1) will do the heavy computation
                        cmd.Data = ComputeData(null, Interlocked.Increment(ref sharedPriority)); //pass around your input
                        proc.ExecuteComplexCommand(cmd);
                        break;
                }
                cmd = cmd.Next;
            }
        }
        private object ComputeData(object input, int priority)
        {
            // we allow only the thread with the priority 0 to perform the heavy computation
            if (priority != 0)
            {
                // for all other threads, it will wait for the thread that got the chance to do the heavy computation to signal
                Monitor.Wait(signalObject);
                return computationResult;
            }
            //heavy computation here 
            computationResult = new object(); // .. implement your heavy logic here
            Monitor.PulseAll(signalObject); // we've computed the result, let all other threads to do use the heavy computation result
            return computationResult;
        }
    }
    }
