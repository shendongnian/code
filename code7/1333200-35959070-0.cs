    public SingleDialogue(<someFormType> im, string stringThingy)
    {
        ...some initialization code...
        im.Disconnected += new EventHandler(im_Disconnected); //Subscribe to the parent's Disconnected event.
    }
    private void im_Disconnected(object sender, EventArgs e) //When the parent disconnects.
    {
        if(this.InvokeRequired) { this.Invoke(() => this.Close()); }
        else { this.Close(); }
    }
