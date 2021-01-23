    public class CommandInterface : ICommandLineInterface {
        public string[] GetCommandLineArgs() {
            return Environment.GetCommandLineArgs();
        }
    }
