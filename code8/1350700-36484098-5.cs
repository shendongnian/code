    public override ISite Site
    {
        get
        {
            return base.Site;
        }
        set
        {
            base.Site = value;
            var svc = this.GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            if (svc != null)
            {
                svc.ComponentAdded -= svc_ComponentAdded;
                svc.ComponentAdded += svc_ComponentAdded;
            }
        }
    }
    void svc_ComponentAdded(object sender, ComponentEventArgs e)
    {
        var c = e.Component as Control;
        if (c != null)
            c.Size = new Size(100, 100);
    }
