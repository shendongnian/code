                string directoryPath = @"D:\Tools\Examples";
            using (StreamWriter file = new StreamWriter(@"C:\Users\gdarmon\Desktop\MacbethTest.txt", true) { AutoFlush = true })
            {
                foreach (string rawImagePath in Directory.GetFiles(directoryPath, "*.raw").Select(t => Path.GetFullPath(t)))
                {
                    image.ReadHeaderLessImage(rawImagePath, width, height, colorOrder, bpp);
                    List<MacbethCheckerBatchesColor> resultWithOutExtraLines =
                    wrapper.DetectMacbethColorChecker(image.Data, image.Width, image.Height, image.ColorOrder,
                                                      image.Bpp, showResult, batchFillFactor);
                    if (resultWithOutExtraLines == null)
                    {
                        file.WriteLine(rawImagePath);
                    }
                }
            }
