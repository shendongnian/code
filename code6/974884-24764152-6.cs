    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleApplication1.Models.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(ConsoleApplication1.Models.MyContext context)
        {
        }
    }
