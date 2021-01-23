    [Serializable]
    public class SetterRepeaterAttribute : MethodInterceptionAspect
    {
        public override void OnInvoke( MethodInterceptionArgs args )
        {
            args.Arguments[0] = ((String)args.Arguments[0]) + ((String)args.Arguments[0]);
            args.Proceed();
        }
    }
