    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.Net.Mail;
    using System.ServiceProcess;
    using System.Timers;
    namespace WindowsService1
    {
        public partial class myservice : ServiceBase
        {
            private EventLog _eventLog1;
            private Timer _timer1;
            public myservice()
            {
                InitializeComponent();
            }
            private void InitialiseService()
            {
                try
                {
                    const string source = "myservice Source";
                    const string name = "myservice Log";
                    _eventLog1 = new EventLog();
                    if (!EventLog.SourceExists(source))
                    {
                        EventLog.CreateEventSource(source, name);
                    }
                    _eventLog1.Source = source;
                    _eventLog1.Log = name;
                    WriteLog("myservice service started on " + DateTime.Now);
                    int intProcessHour;
                    string processHour = ConfigurationManager.AppSettings["ProcessHour"];
                
                    var interval = (int.TryParse(processHour, out intProcessHour) && intProcessHour > 0 &&
                                      intProcessHour < 24
                                    ? intProcessHour
                                    : 1) * 60 * 60 * 1000;
                    _timer1 = new Timer(interval);
                    _timer1.Start();
                    _timer1.Elapsed +=timer1_Elapsed;
                   // Process(); //enable this if you want to process immidiately. Else the timer will process when it elapsed.
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            private void Process()
            {
                try
                {
                    GetParentAccountID("xxx");
                    GetAuditGrade("yyyy");
                    GetAuditID("tttt", "45354345");
                    AuditRecordExists("rrrr", DateTime.Now);
                }
                catch (Exception ex)
                {
                    WriteLog(ex.Message);
                    SendEmail(ex);
                }
            }
            private string GetParentAccountID(string strAgentID)
            {
                /* some logic to bring parentAccount
                */
            }
            private int GetAuditGrade(string strAuditGrade)
            {
                /* some logic to get grades of audits
                */
            }
            private string GetAuditID(string sAgentID, string sDate)
            {
                /* some logic to get audit id
                */
            }
            private bool AuditRecordExists(string strAgentID, DateTime DateAuditStartDate)
            {
                /* some logic to check if audit record already exists
                */
            }
            private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                try
                {
                    WriteLog("myservice timer1_Elapsed started at " + DateTime.Now);
                    Process();
                    WriteLog("myservice timer1_Elapsed finished at " + DateTime.Now);
                }
                catch (Exception ex)
                {
                    WriteLog(ex.Message);
                }
            }
            private void SendEmail(Exception ex)
            {
                try
                {
                    using (SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["SMTPClient"]))
                    {
                        using (MailMessage message = new MailMessage(
                            ConfigurationManager.AppSettings["ErrorSender"],
                            ConfigurationManager.AppSettings["ErrorRecepient"],
                            "myservice - Exception Notice",
                            "An error has occured with the myservice:\n\n" +
                            "Exception Message: " + ex.Message + "\n\n" +
                            "Inner Exception: " + ex.InnerException + "\n\n" +
                            "Date Time: " + DateTime.Now + "\n\n" +
                            "Stack Trace: " + ex.StackTrace))
                        {
                            client.Send(message);
                        }
                    }
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception.Message);
                }
            }
            private void WriteLog(string logEntry)
            {
                try
                {
                    if (!string.IsNullOrEmpty(logEntry) && _eventLog1 != null)
                        _eventLog1.WriteEntry(logEntry);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            protected override void OnStart(string[] args)
            {
                try
                {
                    InitialiseService();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            protected override void OnStop()
            {
                try
                {
                    _timer1.Stop();
                    _timer1.Elapsed -= timer1_Elapsed;
                    WriteLog("myservice service stopped on " + DateTime.Now);
                    _eventLog1.Close();
                    _eventLog1.Dispose();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
