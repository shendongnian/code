    public static Color GetMostUsedColor(Bitmap bmp) {
        using (var bitmap = bmp) {
            var colorsWithCount =
                GetPixels(bitmap)
                    .GroupBy(color => color)
                    .Select(grp =>
                        new {
                            Color = grp.Key,
                            Count = grp.Count()
                        })
                    .OrderByDescending(x => x.Count)
                    .Take(1);
            foreach (var colorWithCount in colorsWithCount) {
                return colorWithCount.Color;
            }
        }
        return Color.Black;
    }
