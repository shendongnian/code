        private void rgbImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point p = Mouse.GetPosition(rgbImage);
          
            var pixelMousePosX = e.GetPosition(rgbImage).X * pixelWidth / rgbImage.ActualWidth;
            var pixelMousePosY = e.GetPosition(rgbImage).Y * pixelHeight / rgbImage.ActualHeight;
            Console.WriteLine("MousePixelX: " + pixelMousePosX + "," + "MousePixelY: " + pixelMousePosY);
            /*Test Square */
            for (int c = 0; c < rectangle.Count; c++)
            {
                for (int n = 0; n < 4; n++)
                {
                    if ((pixelMousePosX > rectangle[c][0].X && pixelMousePosX < rectangle[c][1].X) && (pixelMousePosY > rectangle[c][0].Y && pixelMousePosY < rectangle[c][2].Y))
                    {
                        Console.WriteLine("Triangle HIT is triangle no: " + c);
                    }
                }
            }
        }
