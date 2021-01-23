    public class Program
    {
        public static void Main()
        {
            try
            {
                var timebox = new Timebox(TimeSpan.FromSeconds(1));
                timebox.Execute(() =>
                {
                    // do your thing
                    for (var i = 0; i < 1000; i++)
                    {
                        Console.WriteLine(i);
                    }
                });
                Console.WriteLine("Didn't Time Out");
            }
            catch (TimeoutException e)
            {
                Console.WriteLine("Timed Out");
                // handle it
            }
            catch(Exception e)
            {
                Console.WriteLine("Another exception was thrown in your timeboxed function");
                // handle it
            }
            Console.WriteLine("Program Finished");
            Console.ReadLine();
        }
    }
    public class Timebox
    {
        private readonly TimeSpan _ts;
        public Timebox(TimeSpan ts)
        {
            _ts = ts;
        }
        public void Execute(Action func)
        {
            AppDomain childDomain = null;
            try
            {
                // Construct and initialize settings for a second AppDomain.  Perhaps some of
                // this is unnecessary but perhaps not.
                var domainSetup = new AppDomainSetup()
                {
                    ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                    ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,
                    ApplicationName = AppDomain.CurrentDomain.SetupInformation.ApplicationName,
                    LoaderOptimization = LoaderOptimization.MultiDomainHost
                };
                // Create the child AppDomain
                childDomain = AppDomain.CreateDomain("Timebox Domain", null, domainSetup);
                // Create an instance of the timebox runtime child AppDomain
                var timeboxRuntime = (ITimeboxRuntime)childDomain.CreateInstanceAndUnwrap(
                    typeof(TimeboxRuntime).Assembly.FullName, typeof(TimeboxRuntime).FullName);
                // Start the runtime, by passing it the function we're timboxing
                Exception ex = null;
                var timeoutOccurred = true;
                var task = new Task(() =>
                {
                    ex = timeboxRuntime.Run(func);
                    timeoutOccurred = false;
                });
                // start task, and wait for the alloted timespan.  If the method doesn't finish
                // by then, then we kill the childDomain and throw a TimeoutException
                task.Start();
                task.Wait(_ts);
                // if the timeout occurred then we throw the exception for the caller to handle.
                if(timeoutOccurred)
                {
                    throw new TimeoutException("The child domain timed out");
                }
                // If no timeout occurred, then throw whatever exception was thrown
                // by our child AppDomain, so that calling code "sees" the exception
                // thrown by the code that it passes in.
                if(ex != null)
                {
                    throw ex;
                }
            }
            finally
            {
                // kill the child domain whether or not the function has completed
                if(childDomain != null) AppDomain.Unload(childDomain);
            }
        }
        // don't strictly need this, but I prefer having an interface point to the proxy
        private interface ITimeboxRuntime
        {
            Exception Run(Action action);
        }
        // Need to derive from MarshalByRefObject... proxy is returned across AppDomain boundary.
        private class TimeboxRuntime : MarshalByRefObject, ITimeboxRuntime
        {
            public Exception Run(Action action)
            {
                try
                {
                    // Nike: just do it!
                    action();
                }
                catch(Exception e)
                {
                    // return the exception to be thrown in the calling AppDomain
                    return e;
                }
                return null;
            }
        }
    }
