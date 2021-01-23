    public int AddOrUpdateColor(string ColorCode, int ColorInt)
    {
        var color = db.ColorPalletteColors.FirstOrDefault(c => c.ColorCode == ColorCode);
        if (color == null)
        {
           color = new ColorPaletteColor()
           {
              ColorCode = ColorCode;
           };
           db.ColorPaletteColors.AddObject(color);
        
        }
        color.ColorInt = ColorInt;
        db.SaveChanges();
        
        return color.ColorId; //Shall return the ColorId here.
    }
