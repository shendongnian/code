    public interface ISimple {
        string InputFile { get; }   
        string Data { get; }
        string Command { get; }
    }
    public class Simple : ISimple {
        private Simple(string inputFile, string data) {
            InputFile = inputFile;
            Data = data;
        }
        private void Execute() {
            GetCommand();
        }
        private void GetCommand() {
            Command = Data + ",abc";
        }
        public string InputFile { get; private set; }
        public string Data { get; private set; }
        public string Command { get; private set; }
        // Note.. GetNewInstance is static and it calls the Execute method
        static public ISimple GetNewInstance(string inputFile, string data) {
            var simple =  new Simple(inputFile, data);
            simple.Execute();
            return simple;
        }
    }
