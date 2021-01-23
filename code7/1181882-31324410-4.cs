    public class IoC
    {
        public static IContainer InitializeContainer()
        {
            IContainer container = new Container
            (
                c => c.Scan
                (
                    scan =>
                    {
                        scan.Assembly("assembly1");
                        scan.Assembly("assembly2");
                        scan.LookForRegistries();
                        scan.WithDefaultConventions();
                    }
                )
            );
            return container;
        }
    }
