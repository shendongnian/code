    public static Color GetMostUsedColor(Bitmap bmp) {
            Bitmap b = bmp.Clone() as Bitmap; //This line fixes it
            using (var bitmap = b) {// Then edit the previous var named: bmp to b.
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
