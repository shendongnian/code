    [ProvideProperty("ResourceKey", typeof(Control))]
    public class ControlTextExtender 
        : Component, System.ComponentModel.IExtenderProvider, ISupportInitialize
    {
        private Hashtable Controls;
        public ControlTextExtender() : base() { Controls = new Hashtable(); }
        [Description("Full name of resource class, like YourAppNamespace.Resource1")]
        public string ResourceClassName { get; set; }
        public bool CanExtend(object extendee)
        {
            if (extendee is Control)
                return true;
            return false;
        }
        public string GetResourceKey(Control control)
        {
            return Controls[control] as string;
        }
        public void SetResourceKey(Control control, string key)
        {
            if (string.IsNullOrEmpty(key))
                Controls.Remove(control);
            else
                Controls[control] = key;
        }
        public void BeginInit() { }
        public void EndInit()
        {
            if (DesignMode)
                return;
            var resourceManage = new ResourceManager(this.ResourceClassName, 
                                                     this.GetType().Assembly);
            foreach (Control control in Controls.Keys)
            {
                string value = resourceManage.GetString(Controls[control] as string);
                control.Text = value;
            }
        }
    }
