    static class Design {
        static Font CreateSerifFont() {
            var fonts = new PrivateFontCollection();
            fonts.AddFontFile(@"c:\some_font.ttf");
            return new Font(fonts.Families[0], 12);        
        }
    }
