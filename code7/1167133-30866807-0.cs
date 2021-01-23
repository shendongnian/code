     BitmapImage Image1 = new BitmapImage(ImageStream);
     BitmapImage Image2 = new BitmapImage(ImageStream);
     int X = Image1.Width > Image2.Width ? Image2.Width : Image1.Width;
     int Y = Image1.Hieght > Image2.Height ? Image2.Heigth : Image1.Height;
     for(int x = 0; x < X; x++){
        for(int y = 0; y < Y; y++){
           Color color1 = Image1.GetPixel(x, y);
           Color color2 = Image2.GetPixel(x, y);
           // Do comparison here
        }
     }
     
