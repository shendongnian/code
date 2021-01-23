    public class ServiceBase : ServiceBase
    {
        public override void ApplyChanges<T>(T parameters)
            where T : ParamA    //<-- you forgot this
        {
        }
    }
