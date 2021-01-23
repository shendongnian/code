    public class TestCommand : IDiscordCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public void Run(EventType e)
        {
            e.Channel.SendMessage("Test");
        }
    }
