    public class Form : ContainerControl 
    {
        ...
        protected virtual void OnLoad(EventArgs e) 
        {
            ...
            this.BeginInvoke(new MethodInvoker(CallShownEvent));
            ...
        }
        private void CallShownEvent()
        {
            OnShown(EventArgs.Empty);
        }
        ...
    }
