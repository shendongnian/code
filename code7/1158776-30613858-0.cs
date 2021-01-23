    class RunOnUIThreadAttribute : IMethodInterceptionAspect
    {
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            Control c = (Control)args.Instance;
            if (!c.InvokeRequired)
            {
                args.Proceed();
            }
            else
            {
                c.Invoke((Action)(() => args.Proceed()));
            }
        }
    }
