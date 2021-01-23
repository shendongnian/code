    Color[] excludeColors = { Color.Black, ... };
    var allColors = var colours = typeof(System.Drawing.Color)
                   .GetProperties()
                   .Where(x => x.PropertyType == typeof(System.Drawing.Color))
                   .Select(x => System.Drawing.Color.FromName(x.Name));
    Color[] usedColors = allColors.Except(excludeColors).ToArray();
    
    foreach (var item in Chart2.Series[0].Points)
    {
       Color randomColor = usedColors[rColor.Next(usedColors.Length)];
       item.Color = randomColor; 
    }
