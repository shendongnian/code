    public partial class MyAppService : ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            if(File.Exists(Path.Combine(GetTempPath(), "MyAppIsRunning.doNotDelete"))
            {
                DoSomthingBecauseWeHadABadShutdown();
            }
            File.WriteAllText(Path.Combine(GetTempPath(), "MyAppIsRunning.doNotDelete"), "");
            RunRestOfCode();
        }
        
        protected override void OnStop()
        {
            File.Delete(Path.Combine(GetTempPath(), "MyAppIsRunning.doNotDelete"));
        }
        //...
    }
