	public static void Compress(DirectoryInfo directorySelected, string directoryPath)
        {
            foreach (FileInfo fileToCompress in directorySelected.GetFiles())
            {
                using (FileStream originalFileStream = fileToCompress.OpenRead())
                {
                    if ((File.GetAttributes(fileToCompress.FullName) &
                       FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".tar.gz")
                    {
                        using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".tar.gz"))
                        {
                            using (System.IO.Compression.GZipStream compressionStream = new System.IO.Compression.GZipStream(compressedFileStream,
                               System.IO.Compression.CompressionMode.Compress))
                            {
                                originalFileStream.CopyTo(compressionStream);
                            }
                        }
                        FileInfo info = new FileInfo(directoryPath + "\\" + fileToCompress.Name + ".tar.gz");
                    }
                }
            }
        }
	
	
	3. implement this code in following exception handler try catch block
		try
		{
			TarGzFilePath=@"c:\temp\abc.tar.gz";
			FileStream streams = File.OpenRead(TarGzFilePath);
            string FileName=string.Empty;
            GZipInputStream tarGz = new GZipInputStream(streams);
            TarInputStream tar = new TarInputStream(tarGz);
			// exception will occured in below lines should apply try catch
			
			TarEntry ze;
                try
                {
                    ze = tar.GetNextEntry();// exception occured here "magical number"
                }
                catch (Exception extra)
                {
                    tar.Close();
                    tarGz.Close();
                    streams.Close();
					//please close all above , other wise it will come with exception "tihs process use by another process"
					//rename your file *for better accuracy you can copy file to other location 
					
					File.Move(@"c:\temp\abc.tar.gz", @"c:\temp\abc"); // rename file 
					DirectoryInfo directorySelected = new DirectoryInfo(Path.GetDirectoryName(@"c:\temp\abc"));
					Compress(directorySelected, directoryPath); // directorySelected=c:\temp\abc , directoryPath=c:\temp\abc.tar.gz // process in step 2 function 
					streams = File.OpenRead(TarGzFilePath);
                    tarGz = new GZipInputStream(streams);
                    tar = new TarInputStream(tarGz);
                    ze = tar.GetNextEntry();					
				}
				// do anything with extraction with your code
		}
		catch (exception ex)
		{
			tar.Close();
			tarGz.Close();
			streams.Close();
		}
		
		
