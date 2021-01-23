    buttonUse.Click()+= buttonUse_Click  
    void buttonUse_Click(object sender, RoutedEventArgs e)
        {
           if (radioButtonColor.Checked == true)
        {
         e.Graphics.DrawImage(Properties.Resources.colors, destRect,     srcRect,GraphicsUnit.Pixel);
         graphicsPanel1.Invalidate();
        }
        }
