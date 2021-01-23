    // override the onload event and find all the picture boxes:
    
    private readonly List<PictureBox> _boxes = new List<PictureBox>();
    
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);    
    
        _boxes.AddRange(this.Controls.OfType<PictureBox>()
    }
