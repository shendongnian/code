    // Note non-generic interface
    public class CommandInvoker<T> : ICommandInvoker
    {
        public CommandInvoker<T>(T command, CommandProcessor<T> processor)
        {
            // Assign params to fields...
        }
    
        public void Invoke()
        {
            _processor.Process(_command);
        }
    }
