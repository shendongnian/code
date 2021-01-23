    public class MainProgram
    {
        public MainProgram()
        {
            IKernel kernel = new StandardKernel(new SomeModule());
            Config.ConnectionString = "The connection string";
            AppService appService = kernel.Get<AppService>();
        }
    }  
