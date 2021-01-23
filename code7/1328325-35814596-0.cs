    public class Service : ServiceBase
    {
        public override void ApplyChanges<T>(T parameters)
            where T : ParamA    //<-- you forgot this
        {
            Console.WriteLine(parameters.ParamA);
        }
    }
