    using System;
    using System.Collections.Generic;
    using System.Drawing;
    namespace Project.Services
    {
        class ColorFix
        {
            private string color;
            public Dictionary<string, string> badColors = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            //
            // Constructor, takes Color String
            //
            // @param string(color)
            // @return void
            //
            public ColorFix(string color)
            {
                this.color = color;
                badColors.Add("Grey", "Gray");
            }
            //
            // Fix the Color Exception
            //
            // @return Color
            //
            public Color Fix()
            {
                if (Bad() != null) return (Color)Bad();
                if (Known() != null) return (Color)Known();
                return new Color();
            }
            //
            // Check if Color is a system KnownColor
            //
            // @return Nullable<Color>
            //
            private Color? Known()
            {
                string colorLower = color.ToLower();
                Array colorValues = Enum.GetValues(typeof(KnownColor));
                string[] colorNames = Enum.GetNames(typeof(KnownColor));
                for (int c = 0; c < colorValues.Length; c++)
                {
                    if (colorNames.Equals(colorLower)) return Color.FromKnownColor((KnownColor)colorValues.GetValue(c));
                }
                return null;
            }
            //
            // Check if Color is within the Bad Colors Dictionary
            //
            // @return Nullable<Color>
            //
            private Color? Bad()
            {
                if (badColors.ContainsKey(color))
                {
                    try
                    {
                        return ColorTranslator.FromHtml(badColors[color]);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
                return null;
            }
        }
    }
