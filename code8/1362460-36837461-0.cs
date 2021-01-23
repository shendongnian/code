    public YourUserControl()
    {
        InitializeComponent();
        this.Dispatcher.BeginInvoke((Action)delegate
        {
            Keyboard.Focus(textBoxNumOffre);
        }, DispatcherPriority.Render);
    }
