    using (System.Drawing.Image image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(pic)))
    { 
          //simply assign the image
          pictureBox1.Image =image ;
    }
