    foreach (Control item in this.Controls)
    {
        PictureBox pictureBox = item as PictureBox;
    
        if (pictureBox != null)
        {
            if (item.Tag.ToString() == ipAddress + "OnOff")
            {
                MethodInvoker action = delegate
                { item.Image= ... };
                item.BeginInvoke(action);
                break;
            }
        }
    }
