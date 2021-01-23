        using log4net;
        using System.Reflection;
        [assembly: log4net.Config.XmlConfigurator(Watch = true)]
        namespace ConsoleApplication1
        {
            class Program
            {
                private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                static void Main(string[] args)
                {
                    log.Info("Some text here");
                }
            }
        }
