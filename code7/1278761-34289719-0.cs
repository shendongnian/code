    internal sealed class Configuration : DbMigrationsConfiguration<TasksJobsLib.TasksJobsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            **CommandTimeout = 200;**
        }
        protected override void Seed(TasksJobsLib.TasksJobsDbContext context)
        {
            //nothing
        }
    }
