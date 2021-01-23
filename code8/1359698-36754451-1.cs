    private void tabPage1_load(object sender, EventArgs e)
    {
        ResourceSet rs = new ResourceSet("");
        IDictionaryEnumerator id = rs.GetEnumerator();
        List<Bitmap> CIcons = new List<Bitmap>();
        while (id.MoveNext())
        {
            if (id.Value is Bitmap)
                CIcons.Add((Bitmap)id.Value);
        }
         
        // Vertical aligned: i'll let you figure out how to position them
        int yposition = 0;
        foreach(var bmp in CIcons)
        {
           var button = new Button();   
           button.Location = new Point(0, yposition);
           button.Size = new Size(50, 20); // for example
           button.Visible = true;
           button.BackgroundImage = bmp;
           tabPage1.Controls.Add(button);        
           yposition += 20; // height of button
        
        }
    }
