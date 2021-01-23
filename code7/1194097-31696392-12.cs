    public class AbstractBaseAppSettingsSwitchProxy : AbstractBase
    {
        private readonly IMyFactory factory;
        public AbstractBaseAppSettingsSwitchProxy(IMyFactory factory) {
            this.factory = factory;
        }
        
        public override void SomeFunction() {
            this.factory.Create().SomeFunction();
        }
    }
    
