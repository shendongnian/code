    public class TestCommand : IDiscordCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public void Run(CommandEventArgs e)
        {
            e.Channel.SendMessage("Test");
        }
    }
