    var pic = Convert.FromBase64String(product.Picture);
    using (System.Drawing.Image image = System.Drawing.Image.FromStream(new  System.IO.MemoryStream(pic)))
    { 
      //NOT SURE WHAT TO DO HERE
      pictureBox1.Image =image;
    }
