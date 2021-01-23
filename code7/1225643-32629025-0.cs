    this.SplitView.RegisterPropertyChangedCallback(SplitView.IsPaneOpenProperty, IsPaneOpenPropertyChanged);
    
    
    private void IsPaneOpenPropertyChanged(DependencyObject sender, DependencyProperty dp)
    {
        if (this.SplitView.IsPaneOpen)
        {
            this.SplitView.OpenPaneLength = this.LayoutRoot.ActualWidth * .8;
        }
    }
