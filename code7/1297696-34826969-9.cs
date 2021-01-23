    var images = typeof(Properties.Resources)
                   .GetProperties(BindingFlags.Static | BindingFlags.NonPublic |
                                                        BindingFlags.Public)
                   .Where(p => p.PropertyType == typeof(Bitmap))
                   .Select(x => new { Name = x.Name, Image = x.GetValue(null, null) })
                   .ToList();
