    public int AddOrUpdateColor(string ColorCode, int ColorInt)
    {
        var colorPaletteColor = new ColorPaletteColor 
            {
                ColorCode = ColorCode,
                ColorInt = ColorInt
            };
    
        db.ColorPalletteColors.AddOrUpdate(c => c.ColorCode, colorPaletteColor);   
        db.SaveChanges();
    
        return colorPaletteColor.ColorId; 
    }
