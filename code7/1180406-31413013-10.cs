    private FontInfo prevFontInfo;  // Store previous FontInfo to prevent execution of the event handler multiple times.
    private void OnFontColorPreferencesChanged(object sender, EventArgs e)
    {
        IVsFontAndColorStorage fontAndColorStorage = GetService(typeof(SVsFontAndColorStorage)) as IVsFontAndColorStorage;
        if (fontAndColorStorage != null)
        {
            // GlobalValues.FontsAndColors_TextEditor is found in the registry: HKEY_USERS\.DEFAULT\Software\Microsoft\VisualStudio\[VS_VER]_Config\FontAndColo‌​rs\Text Editor, where VS_VER is the actual Visual Studio version: 10.0, 11.0, 12.0, 14.0, etc.
            if (fontAndColorStorage.OpenCategory(GlobalValues.FontsAndColors_TextEditor, (uint)__FCSTORAGEFLAGS.FCSF_LOADDEFAULTS) == VSConstants.S_OK)
            {
                LOGFONTW[] logFontw = new LOGFONTW[1];  // Only 1 item expected
                FontInfo[] fontInfo = new FontInfo[1];  // Only 1 item expected
                if (fontAndColorStorage.GetFont(logFontw, fontInfo) == VSConstants.S_OK &&
                    !prevFontInfo.Equals(fontInfo[0]))
                {
                    prevFontInfo = fontInfo[0];
                    // FontInfo uses pixels as units, WPF uses points. Conversion between the two is required.
                    double fontSize = (double)new FontSizeConverter().ConvertFrom(string.Format("{0}pt", fontInfo.wPointSize));    
                    FontFamily fontFamily = new FontFamily(fontInfo.bstrFaceName);
                    // There you go, you have the FontFamily and size ready to use.
                }
                fontAndColorStorage.CloseCategory();
            }
        }
    }
