         private string _tempPath = Environment.GetEnvironmentVariable("TEMP") + @"\";
		 private string _zipPath = Environment.GetEnvironmentVariable("TEMP") + @"\" + @"MyZip.zip";
        
        
        /// <summary>
        /// Extracts the contents of a zip file to the 
        /// Temp Folder
        /// </summary>
        private void ExtractZip()
        {
            try
            {                
                //write the resource zip file to the temp directory
                using (Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("<Namespace>.Resources.<filename>.zip"))
                {
                    using (FileStream bw = new FileStream(_zipPath,FileMode.Create))
                    {
                        //read until we reach the end of the file
                        while (stream.Position < stream.Length)
                        {
                            //byte array to hold file bytes
                            byte[] bits = new byte[stream.Length];
                            //read in the bytes
                            stream.Read(bits, 0, (int)stream.Length);
                            //write out the bytes
                            bw.Write(bits, 0, (int)stream.Length);
                        }
                    }
                    stream.Close();
                }
                //extract the contents of the file we created
                UnzipFile(_zipPath, _tempPath);
            }
            catch (Exception e)
            {
                //handle the error
            }
        }
        public void UnzipFile(string zipPath, string folderPath)
        {
            try
            {
                if (!File.Exists(zipPath))
                {
                    throw new FileNotFoundException();
                }
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                Shell32.Shell objShell = new Shell32.Shell();
                Shell32.Folder destinationFolder = objShell.NameSpace(folderPath);
                Shell32.Folder sourceFile = objShell.NameSpace(zipPath);
                foreach (var file in sourceFile.Items())
                {
                    destinationFolder.CopyHere(file, 4 | 16);
                }
            }
            catch (Exception e)
            {
                //handle error
            }
        }
