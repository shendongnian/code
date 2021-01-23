    // Note non-generic interface
    public class CommandInvocation<T> : ICommandInvocation
    {
        public CommandInvocation<T>(T command, CommandProcessor<T> processor)
        {
            // Assign params to fields...
        }
    
        public void Invoke()
        {
            _processor.Process(_command);
        }
    }
