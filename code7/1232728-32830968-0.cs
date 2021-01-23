    public class ChatCommand
    {
        private string _command;
        public string Command { get { return _command; } }
        private string _parameters;
        public string Parameters { get { return _parameters; } }
        public ChatCommand(string command, string parameters) {
            _command = command;
            _parameters = parameters;
        }
    }
