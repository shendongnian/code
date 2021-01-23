    public class ExampleCommand : IrcCommand
    {
        public override void ExecuteCommand(Channel channel)
        {
            channel.SendMessage("Hello World");
        }
    }
    public class DisconnectCommand : IrcCommand
    {
        public override void ExecuteCommand(Channel channel)
        {
            channel.Disconnect();
        }
    }
