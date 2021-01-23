    namespace FakeGDI
    {
        public struct Color 
        {
            private Xamarin.Forms.Color xamarinColor;
            public static Color Yellow
            {
                get
                {
                    return new Color(Xamarin.Forms.Color.Yellow);
                }
            }
            private Color(Xamarin.Forms.Color color)
            {
                this.xamarinColor = color;
            }
            public static implicit operator Xamarin.Forms.Color(Color color)
            {
                return color.xamarinColor;
            }
        }
    }
