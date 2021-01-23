    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Linq;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace My.New.Service
    {
        public partial class MyService : ServiceBase
        {
            private System.Timers.Timer _timer;
    
            public MyService()
            {
                InitializeComponent();
            }
    
            protected override void OnStart(string[] args)
            {
                double interval = Double.Parse(ConfigurationManager.AppSettings["WindowsServiceTimer"].ToString());
    
                _timer = new System.Timers.Timer(interval); //Runs timer every X milliseconds
                _timer.Elapsed += _timer_Elapsed;
                _timer.Start();
            }
    
            void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
    
            }
    
            protected override void OnStop()
            {
            }
        }
    }
