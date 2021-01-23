    public class Service<TParam> : Service where TParam : ParamA
    {
        public override void ApplyChanges<T>(T parameters)
        {
            Console.WriteLine((parameters as TParam).Param2);
        }
    }
