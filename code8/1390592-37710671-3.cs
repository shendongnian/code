    namespace FirstApp
    {
        public class Theme
        {
            public struct ThemeColors
            {
                public Color MainBackground { get; internal set; }
                public Color TextColor { get; internal set; }
                public Color TextShadow { get; internal set; }
            }
            // Example other property
            public string Name { get; set; }
    
            public ThemeColors Colors { get; set; }
        }
        public static class DefaultThemes
        {
            public static Theme MainTheme =>
                new Theme
                {
                    Name = "Main Theme",
                    Colors = new ThemeColors
                    {
                        MainBackground = Color.FromArgb(0xD6, 0x00, 0x00),
                        TextColor = Color.FromArgb(0xDB, 0x3E, 0x25),
                        TextShadow = Color.FromArgb(0xFF, 0x59, 0x40)
                    }
                };
        }
    }
