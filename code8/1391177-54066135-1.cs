    static class Design {
        private static readonly PrivateFontCollection Fonts = new PrivateFontCollection();
        public  static readonly Font                  SerifFont;
    
        static Design() {
            Fonts.AddFontFile(@"c:\some_font.ttf");
            SerifFont = new Font(Fonts.Families[0], 12);
        }
    }
