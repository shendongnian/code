    var images = Properties.Resources.ResourceManager
                           .GetResourceSet(CultureInfo.CurrentCulture, true, true)
                           .Cast<DictionaryEntry>()
                           .Where(x => x.Value.GetType() == typeof(Bitmap))
                           .Select(x => new { Name = x.Key.ToString(), Image = x.Value })
                           .ToList();
