     string directoryPath = @"D:\Tools\Examples";
       
            foreach (string rawImagePath in Directory.GetFiles(directoryPath, "*.raw").Select(Path.GetFullPath))
            {
              using (StreamWriter file = new StreamWriter(@"C:\Users\gdarmon\Desktop\MacbethTest.txt",true))
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
