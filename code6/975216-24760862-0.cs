    #region
    using System;
    using System.Reflection;
    using System.Threading;
    #endregion
    internal class Program
    {
        #region Methods
        private static void Main(string[] args)
        {
            // Get and display the friendly name of the default AppDomain. 
            string callingDomainName = Thread.GetDomain().FriendlyName;
            Console.WriteLine(callingDomainName);
            // Get and display the full name of the EXE assembly. 
            string exeAssembly = Assembly.GetEntryAssembly().FullName;
            Console.WriteLine(exeAssembly);
            // Construct and initialize settings for a second AppDomain.
            var ads = new AppDomainSetup
                      {
                          ApplicationBase = Environment.CurrentDirectory,
                          DisallowBindingRedirects = false,
                          DisallowCodeDownload = true,
                          ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile
                      };
            // Create the second AppDomain.
            AppDomain ad2 = AppDomain.CreateDomain("AD #2", null, ads);
            // Create an instance of MarshalbyRefType in the second AppDomain.  
            // A proxy to the object is returned.
            var mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, typeof(MarshalByRefType).FullName);
            // Call a method on the object via the proxy, passing the  
            // default AppDomain's friendly name in as a parameter.
            mbrt.SomeMethod(new MarshalByRefParameter{ModuleName =  callingDomainName});
            // Unload the second AppDomain. This deletes its object and  
            // invalidates the proxy object.
            AppDomain.Unload(ad2);
            try
            {
                // Call the method again. Note that this time it fails  
                // because the second AppDomain was unloaded.
                mbrt.SomeMethod(new MarshalByRefParameter { ModuleName = callingDomainName });
                Console.WriteLine("Successful call.");
            }
            catch (AppDomainUnloadedException)
            {
                Console.WriteLine("Failed call; this is expected.");
            }
        }
        #endregion
    }
    public interface IMarshalByRefTypeInterface
    {
        void SomeMethod(MarshalByRefParameter parameter);
    }
    public class MarshalByRefType : MarshalByRefObject, IMarshalByRefTypeInterface
    {
        //  Call this method via a proxy. 
        #region Public Methods and Operators
        public void SomeMethod(MarshalByRefParameter parameter)
        {
            // Get this AppDomain's settings and display some of them.
            AppDomainSetup ads = AppDomain.CurrentDomain.SetupInformation;
            Console.WriteLine("AppName={0}, AppBase={1}, ConfigFile={2}", ads.ApplicationName, ads.ApplicationBase, ads.ConfigurationFile);
            // Display the name of the calling AppDomain and the name  
            // of the second domain. 
            // NOTE: The application's thread has transitioned between  
            // AppDomains.
            Console.WriteLine("Calling from '{0}' to '{1}'.", parameter.ModuleName, Thread.GetDomain().FriendlyName);
        }
        #endregion
    }
    [Serializable]
    public class MarshalByRefParameter : MarshalByRefObject
    {
        public string ModuleName { get; set; }
    }
