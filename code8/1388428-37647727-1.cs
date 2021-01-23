    using System;
    using System.ServiceModel;
    using System.ServiceProcess;
    using System.Diagnostics;
    using System.Configuration;
    using System.Timers;
    using System.Collections.Generic;
    
    namespace MyWCF
    {
        public partial class WcfOverHttpService : ServiceBase
        {
            private ServiceHost m_host;
    
            public WcfOverHttpService()
            {
                System.Diagnostics.EventLog.WriteEntry(" WCF Interface", " Constructor called.", EventLogEntryType.Information);
                InitializeComponent();
            }
    
            protected override void OnStart(string[] args)
            {
                try
                {
                    System.Diagnostics.EventLog.WriteEntry(" WCF Interface", "On Start called.", EventLogEntryType.Information);
                    StartWcfService();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.EventLog.WriteEntry(" WCF Interface","On Start failed :"+ex.ToString(), EventLogEntryType.Error);
                    throw ex;
                }
            }
    		
    		 private void StartWcfService()
            {
                try
                {
                    System.Diagnostics.EventLog.WriteEntry(" WCF Interface", "Start Wcf Service.", EventLogEntryType.Information);
                    m_host = new ServiceHost(typeof(MyWCFService));
                    m_host.Open();
                    System.Diagnostics.EventLog.WriteEntry(" WCF Interface", "WCF Service HostOpen.", EventLogEntryType.Information);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.EventLog.WriteEntry(" WCF Interface", "Start WCF Service failed :" + ex.ToString(), EventLogEntryType.Error);
                    throw ex;
                }
            }
    
            protected override void OnStop()
            {
                try
                {
                    System.Diagnostics.EventLog.WriteEntry(" WCF Interface", "On Stop called.", EventLogEntryType.Information);
                    if (m_host != null)
                    {
                        System.Diagnostics.EventLog.WriteEntry(" WCF Interface", "Stop WCF Service.", EventLogEntryType.Information);
                        m_host.Close();
                        m_host = null;
                    }
    
                }
                catch(Exception ex)
                {
                    System.Diagnostics.EventLog.WriteEntry(" WCF Interface", "On Stop failed :" + ex.ToString(), EventLogEntryType.Error);
                    throw ex;
                    //handle exception
                }
            }
          
        }
    }
