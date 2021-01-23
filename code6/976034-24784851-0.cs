    protected override void OnApplyTemplate()
    {
        Button PreviousPageButton = (Button)GetTemplateChild("PreviousPageButton");
        PreviousPageButton.Click += PreviousPageButton_Click;
    }
