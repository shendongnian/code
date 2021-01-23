    public class PluginEventArgs
    {
        public PluginEventArgs(string s) { Text = s; }
        public String Text { get; private set; } // readonly
    }
    public class OtherClass
    {
        public event PluginEventHandler PluginEvent;
        private void RaiseEvent()
        {
            if (null != PluginEvent)
                PluginEvent(this, new PluginEventArgs("some message"));
        }
    }
    public delegate void PluginEventHandler(object sender, PluginEventArgs e);
    public class PluginManager
    {
        
        public event PluginEventHandler PluginEvent;
        private OtherClass otherClass;
        protected virtual void RaiseSampleEvent(string message)
        {
            if (PluginEvent != null)
                PluginEvent(this, new PluginEventArgs(message));
        }
        public PluginManager(OtherClass otherClass)
        {
            this.otherClass = otherClass;
            this.otherClass.PluginEvent += otherClass_PluginEvent;
            SomeMethod();
        }
        void otherClass_PluginEvent(object sender, PluginEventArgs e)
        {
            if (PluginEvent != null)
                PluginEvent(sender, e); // this way the original sender and args are transferred.
        }
        public void SomeMethod()
        {
            //Code
            RaiseSampleEvent("Name of the Plugin");
            //Code
        }
    }
    class test
    {
        public test()
        {
            OtherClass otherClass = new OtherClass();
            PluginManager pluginMg = new PluginManager(otherClass);
            pluginMg.PluginEvent += pluginMg_PluginEvent;
        }
        //I want this event to get triggered when a new plugin has been found
        void pluginMg_PluginEvent(object sender, PluginEventArgs e)
        {
            MessageBox.Show(e.Text);
        }
    }
