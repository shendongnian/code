    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        Path p = GetTemplateChild("path") as Path;
        p.Data = ...
    }
