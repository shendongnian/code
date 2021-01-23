    internal interface IMyHostCallbacks
    {
        void HostCallback(string iSomeDataFromWCFToHost);
    }
    internal static class Host
    {
        public static IMyHostCallbacks Current;
    }
    public partial class MyService : ServiceBase, IMyHostCallbacks
    {
        protected override void OnStart(string[] args)
        {
            //Set the static callback reference.
            Host.Current = this;
            if (m_svcHost != null) m_svcHost.Close();
    
            m_svcHost = new ServiceHost(typeof(MyCommunicationService));
            m_svcHost.Open();
    
            // initialize and work with myObject
        }
        //Here you have data from WCF and myObject available.
        void IMyHostCallbacks.HostCallback(string iSomeDataFromWCFToHost)
        {
            myObject.DoSomething(iSomeDataFromWCFToHost);
        }
    }
