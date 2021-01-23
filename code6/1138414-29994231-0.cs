    // preparation for testing:
    Image image = Image.FromFile("D:\\stop32.png");
    Size size = new Size(77, 77);
    // create the combined control
    // I assume your Label is already there
    Panel pan = new Panel();
    pan.Size = size;
    pan.BackgroundImage = image;
    pan.BackgroundImageLayout = ImageLayout.Stretch;
    label.Parent = pan;  // add the Label to the Panel
    label.Location = Point.Empty;
    label.Text = "TEXT";
    label.BackColor = Color.Transparent;
    // add to (e.g.) the form
    pan.Parent = this;
