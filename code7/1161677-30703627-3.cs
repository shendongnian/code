    using System.Threading.Tasks;  
    public class Example
    {
        void StartOnDifferentThread()
        {
            Task.Factory
                .StartNew(() =>
                {
                    FunctionToRun();
                })
                .ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        // handle result
                    }
                    else if (task.IsFaulted)
                    {
                        // handle error
                    }
                });
        }
    
        void FunctionToRun()
        {
            // do stuff
        }
    }
