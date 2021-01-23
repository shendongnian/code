    var rs  = Properties.Resources.ResourceManager.GetResourceSet(
                             CultureInfo.CurrentUICulture, true, true);
    int yposition = 0;
    foreach (var bmp in rs.OfType<Bitmap>())
    {
        var button = new Button()
        {
            Location = new Point(0, yposition),
            Size = new Size(125, 125),
            Visible = true,
            BackgroundImage = bmp,
        };
        tabPage1.Controls.Add(button);
        yposition += 125; 
    }
