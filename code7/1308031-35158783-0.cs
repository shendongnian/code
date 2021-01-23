    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        GetTemplateParts();
        ItemsPopup.Focusable = true;
    }
    protected void GetTemplateParts()
    {
            Dispatcher.CurrentDispatcher.BeginInvoke(
                DispatcherPriority.Loaded, 
                new Action(() => 
                { 
                    EditableTextBox.SelectionChanged += EditableTextBox_SelectionChanged;
                }));
    }
