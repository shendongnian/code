    public MyContainer()
    {
        this._innerCanvas = new Canvas();
        this.Content = _innerCanvas;
        this.Loaded += ScrollViewer_Loaded;
    }
    public void ScrollViewer_Loaded(object sender, EventArgs e)
    {
        _innerCanvas.Height = this.ActualHeight;
        _innerCanvas.Width = this.ActualWidth;
    } 
