    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Timers;
    using System.Threading.Tasks;
    using MySql.Data.MySqlClient;
    
    namespace bicmwinservice
    {
        public partial class Service1 : ServiceBase
        {
            public Service1()
            {
                InitializeComponent();
            }
    
            public void OnDebug() 
            {
                OnStart(null);
            }
    
            private Timer count;
    
            protected override void OnStart(string[] args)
            {
    
                count = new Timer(1 * 60 * 1000);  // 5 minutes expressed as milliseconds
                count.Elapsed += new ElapsedEventHandler(OnTimerElapsed);
                count.AutoReset = true;
                count.Start();
    
            }
    
            protected override void OnStop()
            {
                System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStop.txt");          
            }
    
            private void OnTimerElapsed(object sender, ElapsedEventArgs e) 
            {
    
    
                    DateTime time = DateTime.Now;
                    DateTime date = DateTime.Now;
    
    
                    string connString = "Server=mysql1003.mochahost.com;Database=snowphil_tester;Uid=snowphil_test;password=snowphil_test;";
                    MySqlConnection conn = new MySqlConnection(connString);
                    MySqlCommand command = conn.CreateCommand();
    
                    string read = File.ReadAllText(@"C:\brcode.txt");
                    
    
                    command.CommandText = "Update branch_monitor SET `date`='" + date.ToString("yyyy'-'MM'-'dd") + "', `time`= '" + time.ToString("HH':'mm':'ss") + "' WHERE branch_code='" + read + "'";
                    conn.Open();
                    command.ExecuteNonQuery();
    
                    conn.Close();
    
            }
    
        }
    }
