    [Serializable]
    public class MyTestAttribute : OnMethodBoundaryAspect
    {
        public override void OnSuccess(MethodExecutionArgs args)
        {
            // Do something.
        }
    }
