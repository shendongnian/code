    public class Command
    {
        private Command(string value)
        {
            Value = value;
        }
        public string Value { get; private set; }
        public static Command SET_STB_MEDIA_CTRL { get; } = new Command("SET STB MEDIA CTRL ");
        public static Command ECHO { get; } = new Command("ECHO");
        public static Command SET_CHANNEL { get; } = new Command("SET CHANNEL ");
        public static Command GET_VOLUMN { get; } = new Command("GET VOLUMN");
        public static Command GET_MAX_VOLUMN { get; } = new Command("GET MAX VOLUMN ");
        public static Command SET_STB_MEDIA_LIST { get; } = new Command("SET STB MEDIA LIST ");
    }
