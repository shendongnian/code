    [DllImport("user32.dll", SetLastError=true)]
     public static extern bool SetSysColors(int cElements, int [] lpaElements, int [] lpaRgbValues);
     public const int COLOR_DESKTOP = 1;
    
     //example color
     System.Drawing.Color sampleColor = System.Drawing.Color.Lime;
    
     //array of elements to change
     int[] elements = {COLOR_DESKTOP};
    
     //array of corresponding colors
     int[] colors = {System.Drawing.ColorTranslator.ToWin32(sampleColor)};
    
     //set the desktop color using p/invoke
     SetSysColors(elements.Length, elements, colors);
    
     //save value in registry so that it will persist
     Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\\Colors", true);
     key.SetValue(@"Background", string.Format("{0} {1} {2}", sampleColor.R, sampleColor.G, sampleColor.B));
