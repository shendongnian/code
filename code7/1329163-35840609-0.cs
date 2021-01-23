    public partial class Service : ServiceBase
        {
            public Service()
            {
                InitializeComponent();
                this.CanHandlePowerEvent = true;
            }
    
            protected override void OnStart(string[] args)
            {
                Library.WriteUserLog("ON");
            }
    
            protected override void OnStop()
            {
                Library.WriteUserLog("OFF");
            }
    
            protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
            {
                switch (powerStatus)
                {
                    case PowerBroadcastStatus.ResumeSuspend:
                        Library.WriteUserLog("ON");
                        break;
                    case PowerBroadcastStatus.Suspend:
                        Library.WriteUserLog("OFF");
                        break;
                        // other statuses....
                }
                return base.OnPowerEvent(powerStatus);
            }
    
            }
        }
