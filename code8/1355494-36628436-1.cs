    public class CommandInterface : ICommandInterface {
        public string[] GetCommandLineArgs() {
            return Environment.GetCommandLineArgs();
        }
    }
