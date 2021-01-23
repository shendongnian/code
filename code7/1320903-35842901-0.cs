       byte[] img = limg.getImage();
       if (img != null)
       {
           MemoryStream ms = new MemoryStream(img);
           newImg = System.Drawing.Image.FromStream(ms);
           GifImage gi = new GifImage(newImg);
           for (int i = 0; i < gi.GetFrameCount; i++)
           {
               this.SetPicture(gi.GetNextFrame(), limg.getWord());
           }
       }
