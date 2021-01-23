    [Serializable]
    public class EnsureReturnValueNotNullAttribute : MethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            base.OnInvoke(args);
            if (args.ReturnValue == null)
            {
                Console.WriteLine(
                    "OMG, thing was null!!!!");
            }
        }
    }
