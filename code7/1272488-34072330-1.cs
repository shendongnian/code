    partial class Plugin {
        public virtual void Run(object source, System.EventArgs args)
        {
            if(!Enabled)
                return;
        }
    }
