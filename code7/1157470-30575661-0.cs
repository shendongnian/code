    		static void Main (string[] args) {
    
    			string directoryPath = @"F:\logs";
    			using (StreamWriter file = new StreamWriter(@"f:\development\testing.txt", true)) {
    				foreach (string rawImagePath in Directory.GetFiles(directoryPath, "*.log").Select(Path.GetFullPath)) {
    					//image.ReadHeaderLessImage(rawImagePath, width, height, colorOrder, bpp);
    
    /*
    					List<MacbethCheckerBatchesColor> resultWithOutExtraLines =
    					wrapper.DetectMacbethColorChecker(image.Data, image.Width, image.Height, image.ColorOrder,
    													  image.Bpp, showResult, batchFillFactor);
    */
    					//if (resultWithOutExtraLines == null) {
    						file.WriteLine(rawImagePath);
    					//}
    				}
    			}
    		}
    	}
