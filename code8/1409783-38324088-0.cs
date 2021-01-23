    if (ivrMenu.X + ivrMenu.Width < _designerControl.AutoScrollPosition.X * (-1))
        MessageBox.Show("Left");
    if (ivrMenu.X + ivrMenu.Width > _designerControl.ClientSize.Width - _designerControl.AutoScrollPosition.X)
        MessageBox.Show("Right");
    if (ivrMenu.Y + ivrMenu.Height < _designerControl.AutoScrollPosition.Y * (-1))
        MessageBox.Show("Up");
    if (ivrMenu.Y + ivrMenu.Height > _designerControl.ClientSize.Height - _designerControl.AutoScrollPosition.Y)
        MessageBox.Show("Down");
