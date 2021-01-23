    private void cbStatus_DrawItem(object sender, ListBoxDrawItemEventArgs e)
    {
        string item = e.Item as string;
        if (item != null)
        {
            switch (item)
            {
                case "1":
                    e.Appearance.BackColor = Color.Green;
                    break;
                case "2":
                    e.Appearance.BackColor = Color.Orange;
                    break;
                case "3":
                    e.Appearance.BackColor = Color.Red;
                    break;
            }
        
            e.Appearance.DrawBackground(e.Cache, e.Bounds);
            e.Appearance.DrawString(e.Cache, item, e.Bounds);
        
            e.Handled = true;
        }
    }
