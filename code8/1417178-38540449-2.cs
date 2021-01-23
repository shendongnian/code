    public ManipulationImage()
        : base()
    {
        //// ...
        this.ManipulationDelta += this.ManipulationImage_ManipulationDelta;
        //// ...
    }
        
    private void ManipulationImage_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        var ct = this.RenderTransform as CompositeTransform;
        if (object.ReferenceEquals(ct, null))
        {
            return; // or throw exception, depends on use
        }
        var args = new ManipulationCommandArgs(ct, e);
        if (this.ManipulationCommand?.CanExecute(args) == true)
        {
            // we don't need the reference to the actual image, only to the parameters
            this.ManipulationCommand?.Execute(args);
        }
    }
