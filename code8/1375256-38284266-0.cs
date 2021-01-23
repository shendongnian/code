    public class RandomColors
    {
        static Color lastColor = Color.Empty;
    
        static KnownColor[] colorValues = (KnownColor[]) Enum.GetValues(typeof(KnownColor));
            
        static Random rnd = new Random();
        const int MaxColor = 256;
        static RandomColors()
        {
            lastColor = Color.FromArgb(rnd.Next(MaxColor), rnd.Next(MaxColor), rnd.Next(MaxColor));
        }
    
        public static Color[] Generate(int n)
        {
            var colors = new Color[n];
            if (n <= colorValues.Length)
            {
                // known color suggestion from TAW
                // http://stackoverflow.com/questions/37234131/how-to-generate-randomly-colors-that-is-easily-recognizable-from-each-other#comment61999963_37234131
                var step = (colorValues.Length-1) / n;
                var colorIndex = step;
                step = step == 0 ? 1 : step; // hacky
                for(int i=0; i<n; i++ )
                {
                    colors[i] = Color.FromKnownColor(colorValues[colorIndex]);
                    colorIndex += step;
                }
            } else
            {
                for(int i=0; i<n; i++)
                {
                    colors[i] = GetNext();
                }
            }
    
            return colors;
        }
    
        public static Color GetNext()
        {
            // use the previous value as a mix color as demonstrated by David Crow
            // http://stackoverflow.com/a/43235/578411
            Color nextColor = Color.FromArgb(
                (rnd.Next(MaxColor) + lastColor.R)/2, 
                (rnd.Next(MaxColor) + lastColor.G)/2, 
                (rnd.Next(MaxColor) + lastColor.B)/2
                );
            lastColor = nextColor;
            return nextColor;
        }
    }
