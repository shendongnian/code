The anonymous no-op delegate must conform to the delegate definition, so all I had to add was add the argument ((string foo) in this example):
    public partial class MainWindow
    {
        public UserMessage.ProcessUserMessageDelegate ProcessUserMessage = delegate (string foo){ };
    }
    public class UserMessage
    {
        public delegate void ProcessUserMessageDelegate(string foo);
    }
