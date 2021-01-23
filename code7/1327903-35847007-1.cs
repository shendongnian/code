        public class NinjectProgram
        {
            //Gets the inject kernal for the program.
            public static IKernel Kernel { get; protected set; }
        }
        public class Program : NinjectProgram
        {
            [STAThread]
            private static void Main()
            {
                Kernel = new StandardKernel();
                Kernel.Load(new ApplicationModule());
        
                Application.Run(new ApplicationShellView());
            }
        }
        public class ApplicationModule : NinjectModule
        {
            public override void Load()
            {
                //Here is where we define what implementations map to what interfaces.
                Bind<IApplicationShellController>().To<ApplicationShellController>();
        
                //We can also load other modules this project depends on.
                Kernel.Load(new NinjectModule());
            }
        }
