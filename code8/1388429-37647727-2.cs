    using System;
    using System.ServiceModel;
    using System.ServiceProcess;
    using System.Diagnostics;
    using System.Configuration;
    using System.Timers;
    using System.Collections.Generic;
    
    namespace MyAppNameSpace
    {
        public partial class MyWCFService : ServiceBase
        {
            private ServiceHost m_host;
            System.Timers.Timer MyProductionTimer = null;
            bool _MyProductionRunOnce = false;
           
            //// Put this values in Config 
            private string MyProductionSchedule = "DAILY";
            private string MyProductionToRun = "MANY";
            private string MyProductionStartTime = "10:00 PM";
            private int MyProductionPollInterval = 60000;
    
          
            public MyWCFService()
            {
                System.Diagnostics.EventLog.WriteEntry("My  WCF Interface Constructor", " Constructor called.", EventLogEntryType.Information);
    
                InitializeComponent();
    			//Create Timer Object and register tick event
                 this.MyProductionTimer = new System.Timers.Timer(MyProductionPollInterval);
                 this.MyProductionTimer.Elapsed += new ElapsedEventHandler(this.MyProductionTimer_Tick);
    
                
            }
    
            protected override void OnStart(string[] args)
            {
                try
                {
                    System.Diagnostics.EventLog.WriteEntry("My  WCF Interface Start", "On Start called.", EventLogEntryType.Information);
    
                    StartWcfService();
    
    				 // Setup timer and start it 
                    this.MyProductionTimer.Interval = MyProductionPollInterval;
                    this.MyProductionTimer.Enabled = true;
                    this.MyProductionTimer.Start();
                    System.Diagnostics.EventLog.WriteEntry("My  MyProduction Timer Start", "MyProduction Timer Start At :" + DateTime.Now.ToString(), EventLogEntryType.Information);
    
                }
                catch (Exception ex)
                {
                    System.Diagnostics.EventLog.WriteEntry("My  WCF Interface Start Error","On Start failed :"+ex.ToString(), EventLogEntryType.Error);
    
                    throw ex;
                }
            }
    
            protected override void OnStop()
            {
                try
                {
                    System.Diagnostics.EventLog.WriteEntry("My  WCF Interface Stop", "On Stop called.", EventLogEntryType.Information);
    
    				//Stop the timer
                    this.MyProductionTimer.Stop();
                    System.Diagnostics.EventLog.WriteEntry("My  MyProduction Timer Stop", "MyProduction Timer Stopped At :" + DateTime.Now.ToString(), EventLogEntryType.Information);
    				
                    if (m_host != null)
                    {
                        System.Diagnostics.EventLog.WriteEntry("My  WCF Interface Stopped", "Stop Wc fService.", EventLogEntryType.Information);
    
                        m_host.Close();
                        m_host = null;
                    }
    
                   
                }
                catch(Exception ex)
                {
                    System.Diagnostics.EventLog.WriteEntry("My  WCF Interface Stop Error", "On Stop failed :" + ex.ToString(), EventLogEntryType.Error);
    
                    throw ex;
                    //handle exception
                }
            }
    
    		//Timer Tick Event
            private void MyProductionTimer_Tick(object sender, EventArgs e)
            {
                this.MyProductionTimer.Stop();
                this.MyProductionTimer.Interval = MyProductionPollInterval;
                bool runFlag = false;
    
                try
                {
    
    			    // Find out if it is time to run logic based on schedule
                    string dw = DateTime.Now.DayOfWeek.ToString();
    
                    if ((MyProductionSchedule.ToUpper() == "DAILY" && MyProductionToRun.ToUpper() == "ONCE") ||
                        (MyProductionSchedule.ToUpper() == dw.ToUpper() && MyProductionToRun.ToUpper() == "ONCE"))
                    {
                        if (checkPolTime(MyProductionStartTime))
                            _MyProductionRunOnce = true;
    
                        if (_MyProductionRunOnce)
                        {
                            _MyProductionRunOnce = false;
                            runFlag = true;
                        }
                    }
                    else if ((MyProductionSchedule.ToUpper() == "DAILY" && MyProductionToRun.ToUpper() == "MANY") ||
                            (MyProductionSchedule.ToUpper() == dw.ToUpper() && MyProductionToRun.ToUpper() == "MANY"))
                    {
                        if (!_MyProductionRunOnce)
                        {
                            if (checkPolTime(MyProductionStartTime))
                                _MyProductionRunOnce = true;
                        }
    
                        if (_MyProductionRunOnce)
                            runFlag = true;
                    }
                    else
                    {
                        _MyProductionRunOnce = false;
                    }
    
                    if (runFlag)
                    {
    					// Your Timer Business Logic  goes here
                    }
                }
                catch (Exception exc)
                {
                    System.Diagnostics.EventLog.WriteEntry(" MyProduction Timer Error",
                        exc.Message, EventLogEntryType.Error);
                }
                finally
                {
                    this.MyProductionTimer.Start();//To restart the processing of production
                }
            }
            private void StartWcfService()
            {
                try
                {
                    System.Diagnostics.EventLog.WriteEntry("My  WCF Interface Create Host", "Start Wcf Service.", EventLogEntryType.Information);
                    m_host = new ServiceHost(typeof(WcfService));
                    m_host.Open();
                    System.Diagnostics.EventLog.WriteEntry("My  WCF Interface Host Opened", "WCF Service HostOpen.", EventLogEntryType.Information);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.EventLog.WriteEntry("My  WCF Interface Exception", "Start WCF Service failed :" + ex.ToString(), EventLogEntryType.Error);
    
                    throw ex;
                }
            }
    
    		// Utility to check if it is time to run the timer logic
            public static bool checkPolTime(string ProdStartTime)
            {
                DateTime t1 = DateTime.Now;
                DateTime t2 = Convert.ToDateTime(ProdStartTime);
                int i = DateTime.Compare(t1, t2);
                if (i >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
               }
            }
    
           
        }
    }
