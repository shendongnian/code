            var assembly = typeof(CookModule).GetTypeInfo().Assembly;
            using (var imageStream = assembly.GetManifestResourceStream("UWP.ClassLibrary.210644575939381015.jpg"))
            using (var memStream = new MemoryStream())
            {
                await imageStream.CopyToAsync(memStream);
                memStream.Position = 0;
                using (var raStream = memStream.AsRandomAccessStream())
                {
                    var bitmap = new BitmapImage();
                    bitmap.SetSource(raStream);
                    display.Source = bitmap;
                }
            }
