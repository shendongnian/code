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
