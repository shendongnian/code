    public class Simple : ISimple {
        
        public Simple(IFileWrapper inputFile, string data) {
            InputFile = inputFile;
            Data = data;
            Execute();
        }
        private void Execute() {
            GetCommand();
            // Other private methods
        }
        private void GetCommand() {
            Command = Data + ",abc";
        }
        public IFileWrapper InputFile { get; private set; }
        public string Data { get; private set; }
        public string Command { get; private set; }
    }
