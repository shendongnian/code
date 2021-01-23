    public class Program
    {
        static void Main(string[] args)
        {
            var client = new DiscordClient();
            client.Connect(" ");
            RegisterCommands(client.Services.Get<CommandService>());
        }
        public static void RegisterCommands(CommandService commandService)
        {
            var commands = new List<IDiscordCommand>();
            commands.Add(new TestCommand());
            foreach (var command in commands)
            {
                commandService.CreateCommand(command.Name)
                    .Description(command.Description)
                    .Do(command.Run);
            }
        }
    }
