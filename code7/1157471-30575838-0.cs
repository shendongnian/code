                string directoryPath = @"D:\Tools\Examples";
            foreach (string rawImagePath in Directory.GetFiles(directoryPath, "*.raw").Select(Path.GetFullPath))
            {
                image.ReadHeaderLessImage(rawImagePath, width, height, colorOrder, bpp);
                List<MacbethCheckerBatchesColor> resultWithOutExtraLines =
                wrapper.DetectMacbethColorChecker(image.Data, image.Width, image.Height, image.ColorOrder,
                                                  image.Bpp, showResult, batchFillFactor);
                if (resultWithOutExtraLines == null)
                {
                    File.AppendAllLines(@"C:\Users\gdarmon\Desktop\MacbethTest.txt", new[] { rawImagePath });
                }
            }
