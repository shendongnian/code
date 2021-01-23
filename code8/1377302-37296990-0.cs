    private void SetMyButtonIcon()
    {
        // Assign an image to the button.
        button1.Image = Image.FromFile("C:\\Graphics\\My.ico");
        // Align the image and text on the button.
        button1.ImageAlign = ContentAlignment.MiddleRight;    
        button1.TextAlign = ContentAlignment.MiddleLeft;
    }
