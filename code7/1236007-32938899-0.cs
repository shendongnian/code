    namespace myApplication
    {
    [Application]
    public class myApplication : Application
    {
    public bool enabled; {get; set;}
        public override void OnCreate()
        {
            base.OnCreate();
            enabled = false;
        }
    }
    
