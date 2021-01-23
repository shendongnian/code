    public interface IDiscordCommand
    {
        string Name { get; set; }
        string Description { get; set; }
        void Run(CommandEventArgs e);
    }
