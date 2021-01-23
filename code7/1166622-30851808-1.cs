    void pictureBox1_MouseWheel(object sender, MouseEventArgs e) 
    {
       if (pictureBox1.Image != null)
       {
           if (e.Delta < 0)
           {
               zoom = zoom * 1.05;
           }
           else
           {
               if (zoom != 1.0)
               {
                   zoom = zoom / 1.05;
               }
           }
           txttextBox1.Text = zoom.ToString();
           pictureBox1.Width = (int)Math.Round(pictureBox1.Image.Width * zoom);
           pictureBox1.Height = (int)Math.Round(pictureBox1.Image.Height * zoom);
       }
    }  
