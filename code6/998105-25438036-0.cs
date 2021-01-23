    View:
    // Constructor
    public View()
    {
        // However you're setting your VM, i.e. DI or new-ing up the VM
        // Subscribe to the event
        vm.ImageGeneratedEvent += this.OnImageGeneratedEvent;
    }
    private void OnImageGeneratedEvent(object sender, ImageGeneratedEventArgs args)
    {
        // Call your SaveImage in the event handler
        _control.SaveImage(args.Path);
    }
    View Model:
    ...
    public event EventHandler<ImageGeneratedEventArgs> ImageGeneratedEvent;
    ...
    // Command body
    {
        var path = GeneratePath();
        // Send event to the View
        this.NotifyImageGeneratedEvent(path)
    }
    ...
    private void NotifyImageGeneratedEvent(string path)
    {
        ImageGeneratedEventArgs args = new ImageGeneratedEventArgs(path);
        
        if (this.ImageGeneratedEvent!= null)
        {
            this.ImageGeneratedEvent(this, args);
        }
    }
    
    ImageGeneratedEventArgs:
    public class ImageGeneratedEventArgs : EventArgs
    {
        public string Path { get; set; }
        public ImageGeneratedEventArgs(string path)
        {
            this.Path = path;
        }
    }
