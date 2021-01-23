    class Program
    {
        static void Main(string[] args)
        {
            var image = (Bitmap)Image.FromFile(@"C:\temp\colorimage3.bmp");
            var mostUsedColor = GetMostUsedColor(image);
            var color = GetNearestColor(mostUsedColor);
            Console.WriteLine(color.Name);
            Console.ReadKey();
        }
        
        private static Color GetNearestColor(Color inputColor)
        {
            var inputRed = Convert.ToDouble(inputColor.R);
            var inputGreen = Convert.ToDouble(inputColor.G);
            var inputBlue = Convert.ToDouble(inputColor.B);
            var colors = new List<Color>();
            foreach (var knownColor in Enum.GetValues(typeof(KnownColor)))
            {
                var color = Color.FromKnownColor((KnownColor) knownColor);
                if (!color.IsSystemColor)
                    colors.Add(color);
            }
            var nearestColor = Color.Empty;
            var distance = 500.0;
            foreach (var color in colors)
            {
                // Compute Euclidean distance between the two colors
                var testRed = Math.Pow(Convert.ToDouble(color.R) - inputRed, 2.0);
                var testGreen = Math.Pow(Convert.ToDouble(color.G) - inputGreen, 2.0);
                var testBlue = Math.Pow(Convert.ToDouble(color.B) - inputBlue, 2.0);
                var tempDistance = Math.Sqrt(testBlue + testGreen + testRed);
                if (tempDistance == 0.0)
                    return color;
                if (tempDistance < distance)
                {
                    distance = tempDistance;
                    nearestColor = color;
                }
            }
            return nearestColor;
        }
        
        public static Color GetMostUsedColor(Bitmap bitMap)
        {
            var colorIncidence = new Dictionary<int, int>();
            for (var x = 0; x < bitMap.Size.Width; x++)
            for (var y = 0; y < bitMap.Size.Height; y++)
            {
                var pixelColor = bitMap.GetPixel(x, y).ToArgb();
                if (colorIncidence.Keys.Contains(pixelColor))
                    colorIncidence[pixelColor]++;
                else
                    colorIncidence.Add(pixelColor, 1);
            }
            return Color.FromArgb(colorIncidence.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value).First().Key);
        }
    }
