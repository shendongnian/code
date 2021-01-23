        //palette is a 256x3 table
        public static Bitmap GetPictureFromData(int w, int h, byte[] data, byte[][] palette)
        {
          Bitmap pic = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
          Color c;
          for (int i = 0; i < data.Length; i++)
          {
              byte[] color_bytes = palette[data[i]];
              c = Color.FromArgb(color_bytes[0], color_bytes[1], color_bytes[2]);
              pic.SetPixel(i % w, i / w, c);
          }
          return pic;
        }
