    class Program
        {
            public class TaskState
            {
                public bool Ended { get; set; }
            }
    
            static void Main(string[] args)
            {
                var task = Task.FromResult("Stackoverflow");
                var state = new TaskState();
                task.ContinueWith((result, continuationState) =>
                {
                    Console.WriteLine("in first");
    
    
                }, state).ContinueWith((result, continuationState) =>
                {
                    if (!state.Ended)
                        Console.WriteLine("in second");
                    state.Ended = true;
    
                }, state).ContinueWith((result, continuationState) =>
                {
                    if (!state.Ended)
                        Console.WriteLine("in third");
                    state.Ended = true;
    
                }, state);
                Console.ReadLine();
            }
    
        }
