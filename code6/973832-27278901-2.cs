    public Image InputImage
    {
        get { return InputPicture.Image; }
        set { InputPicture.Image = value; }
    }
    public PictureBoxSizeMode InputImageLayout
    {
        get { return InputPicture.SizeMode; }
        set { InputPicture.SizeMode = value; }
    }
    public char PasswordCharacter
    {
        get { return TextBox.PasswordChar; }
        set { TextBox.PasswordChar = value; }
    }
    public bool ShowInputImage
    {
        get { return InputPicture.Visible; }
        set { InputPicture.Visible = value; }
    }
