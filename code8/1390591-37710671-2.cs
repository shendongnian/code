    namespace FirstApp
    {
        public static class ColorSchemes
        {
            public struct ThemeColors
            {
                public Color MainBackground { get; internal set;  }
                public Color TextColor { get; internal set; }
                public Color TextShadow { get; internal set;  }
            }
    
            private static readonly ThemeColors[] Colors =
            {
                new ThemeColors
                {
                    MainBackground = Color.FromArgb(0xD6, 0x00, 0x00),
                    TextColor = Color.FromArgb(0xDB, 0x3E, 0x25),
                    TextShadow = Color.FromArgb(0xFF, 0x59, 0x40)
                }
            };
    
            public static ThemeColors GetThemeColors(int themeIndex)
            {
                if (themeIndex < 0 || themeIndex >= Colors.Length)
                    throw new ArgumentOutOfRangeException();
                return Colors[themeIndex];
            }
        }
    }
