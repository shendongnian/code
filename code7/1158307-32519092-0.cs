    private Color getRandomColor()
        {
            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor[] badColors = { KnownColor.Black, KnownColor.White };
            IEnumerable<KnownColor> colors = names.Except(badColors);
            var okColors = colors.ToArray();
            KnownColor randomColorName = okColors[randomGen.Next(names.Length)];
            
            return Color.FromKnownColor(randomColorName);
        }
