    public class ServiceShell:MarshalByRefObject
    {
         internal static ServiceHost MyServiceHost = null;
         public void Run()
         {
             if (MyServiceHost != null)
             {
                 MyServiceHost.Close();
             }
             try
             {
                 MyServiceHost = new ServiceHost(typeof(MyWCFService));
                 MyServiceHost.Open();
             }
             catch (Exception)
             {
             }          
         }
         public void Stop()
         {
             if (MyServiceHost!= null)
             {
                 MyServiceHost.Close();
                 MyServiceHost = null;
             }
         }
    }
