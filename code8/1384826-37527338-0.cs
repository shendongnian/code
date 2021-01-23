		public void printWithPrinter(string[] fileNames, string printerName)
		{
			var fileStreams = fileNames
				.Select(fileName => (Stream)File.OpenRead(fileName)).ToList();
			var bundleFileName = Path.GetTempPath();
			try
			{
				
				try
				{
					var bundleBytes = new PdfMerge.PdfMerge().MergeFiles(fileStreams);
					using (var bundleStream = File.OpenWrite(bundleFileName))
					{
						bundleStream.Write(bundleBytes, 0, bundleBytes.Length);
					}
				}
				finally 
				{
						fileStreams.ForEach(s => s.Dispose());
				}
				printWithPrinter(bundleFileName, printerName);
			}
			finally 
			{
				if (File.Exists(bundleFileName))
					File.Delete(bundleFileName);
			}
		}
