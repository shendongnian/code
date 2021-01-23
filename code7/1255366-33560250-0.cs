    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
            RoleEnvironment.Stopping += (sender, args) =>
                {
                    messagesListener.Stop(true);
                    Logger.LogInfo("Website is stopping. InstanceNo = " + instanceNo);
                };
            return base.OnStart();
        }
        public override void OnStop()
        {
            // you can also put stuff here to test
            base.OnStop();
        }
    }
