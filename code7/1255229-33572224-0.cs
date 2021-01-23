    VirtualDesktop.CurrentChanged += (o, e) =>
    {
        this.Dispatcher.Invoke(() =>
        {
            var h = new WindowInteropHelper(this).Handle;
    
            if (!VirtualDesktopHelper.IsCurrentVirtualDesktop(h))
            {
                this.MoveToDesktop(VirtualDesktop.Current);
            }
        });
    };
