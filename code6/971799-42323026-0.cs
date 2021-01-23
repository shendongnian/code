    _wf = new WorkflowDesigner();
    ((System.Windows.FrameworkElement)_wf.View).Loaded += (s, e) =>
    {
        var designerView = _wf.Context.Services.GetService<DesignerView>();
        if (designerView != null)
            designerView.WorkflowShellBarItemVisibility =
                        ShellBarItemVisibility.Variables |
                        //ShellBarItemVisibility.Arguments |  
                        //ShellBarItemVisibility.Imports |     
                        ShellBarItemVisibility.PanMode |
                        ShellBarItemVisibility.MiniMap |
                        ShellBarItemVisibility.Zoom;
    };
