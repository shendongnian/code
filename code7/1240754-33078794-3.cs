        public class BaseContext<TContext>
            : DbContext where TContext : DbContext
        {
            static BaseContext()
            {
                //By setting it NULL, we are making it work with Existing Adventure Works database
                Database.SetInitializer<TContext>(null);
            }
            protected BaseContext()
                : base("name=AdventureWorksContext") //Points to Connection String in Config file
            { }
        }
