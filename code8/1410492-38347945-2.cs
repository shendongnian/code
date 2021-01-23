    private void pic_MouseClick(object sender, MouseEventArgs e)
    {
        if (ModifierKeys != Keys.Control)
            return;
        selectedIndex = -1;
        for (int i = 0; i < Shapes.Count; i++)
        {
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(Shapes[i]);
                if (path.IsVisible(e.Location))
                    selectedIndex = i;
            }
        }
        pic.Invalidate();
    }
