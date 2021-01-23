    //Save the Color from Colorpicker as HEX value to Settings:
    System.Drawing.Color color = backgroundColor.SelectedColor;
    //Assuming you store to string:
    Properties.Settings.Default.backgroundColorSt = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
            
    //Later when reading the value from settings simply do this:
    System.Windows.Media.ColorConverter.ConvertFromString(Properties.Settings.Default.backgroundColorSt);
