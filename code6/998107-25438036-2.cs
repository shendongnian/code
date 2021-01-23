    public event EventHandler<ImageGeneratedEventArgs> ImageGeneratedEvent;
    // Command body
    {
        var path = GeneratePath();
        // Send event to the View
        this.NotifyImageGeneratedEvent(path)
    }
    private void NotifyImageGeneratedEvent(string path)
    {
        ImageGeneratedEventArgs args = new ImageGeneratedEventArgs(path);
        
        if (this.ImageGeneratedEvent!= null)
        {
            this.ImageGeneratedEvent(this, args);
        }
    }
    
