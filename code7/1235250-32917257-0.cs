     private void setPixelColors(int xCord, int yCord, int newColor)
     {
         using (bit.GetBitmapContext())
         {
             _setPixelColors(xCord, yCord, newColor);
         }
     }
     private void _setPixelColors(int xCord, int yCord, int newColor)
     {
        Color color = bit.GetPixel(xCord, yCord);
        if (color.R <= 5 && color.G <= 5 && color.B <= 5 || newColor == ConvertColorToInt(color))
        {
            //Debug.WriteLine("The color was black or same returning");
            return;
        }
        setPixelColors(xCord + 1, yCord, newColor);
        setPixelColors(xCord, yCord + 1, newColor);
        setPixelColors(xCord - 1, yCord, newColor);
        setPixelColors(xCord, yCord - 1, newColor);
        //Debug.WriteLine("Setting the color here");
        bit.SetPixel(xCord, yCord, newColor);
     }
