    [BindableAttribute(true)]
    public Image Logo
    {
        get {return this.pictureBox1.Image;}
        set
        {
            this.pictureBox1.Image = image;
        }
    }
