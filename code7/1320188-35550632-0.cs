    public int AddOrUpdateColor(string ColorCode, int ColorInt)
    {
        var color = new ColorPaletteColor 
            {
                ColorCode = ColorCode,
                ColorInt = ColorInt
            };
        
        db.ColorPalletteColors.AddOrUpdate(c => c.ColorCode, color);   
        db.SaveChanges();
    
        return color.ColorId; 
    }
