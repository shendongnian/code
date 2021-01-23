    protected override void OnControlAdded(ControlEventArgs e)
    {
        base.OnControlAdded(e);
        if (this.IsHandleCreated)
        {
            base.BeginInvoke(new Action(() =>
            {
                e.Control.Size = new Size(100, 100);
                var svc = this.GetService(typeof(IComponentChangeService)) 
                              as IComponentChangeService;
                if (svc != null)
                    svc.OnComponentChanged(e.Control, 
                       TypeDescriptor.GetProperties(e.Control)["Size"], null, null);
            }));
        }
    }
