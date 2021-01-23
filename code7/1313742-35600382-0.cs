        public void ReplicateFile(string destinationFile, string sourceFile){
            if (!Directory.Exists(GetRoutePathFromFile(sourceFile)))
                return;           
            if (!File.Exists(sourceFile))                
                return;           
            if (Directory.Exists(GetRoutePathFromFile(destinationFile))){
                if (File.Exists(destinationFile)){                                         
                    UpdateLatestWaveFileContent(destinationFile, sourceFile);
                }else{                 
                    CopyWaveFile(destinationFile, sourceFile);
                }
            }else{                        
                Directory.CreateDirectory(GetRoutePathFromFile(destinationFile));
                CopyWaveFile(destinationFile, sourceFile);
            }
        }
        private static string GetRoutePathFromFile(string file){
            var rootPath = Directory.GetParent(file);
            return rootPath.FullName;
        }
        private static void CopyWaveFile(string destination, string source){
            var sourceMemoryStream = new MemoryStream();
            using (var fs = File.Open(source, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)){
                fs.CopyTo(sourceMemoryStream);
            }            
            using (var fs = new FileStream(destination, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.ReadWrite)){
                sourceMemoryStream.WriteTo(fs);               
            }
        }
        private static void UpdateLatestWaveFileContent(string destinationFile, string sourceFile){
            var sourceMemoryStream = new MemoryStream();
            long offset = 0;
            using (var fs = File.Open(destinationFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)){
                offset = fs.Length;
            }
            using (var fs = File.Open(sourceFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)){
                fs.CopyTo(sourceMemoryStream);
            }
            var length = sourceMemoryStream.Length - offset;            
            var buffer = sourceMemoryStream.GetBuffer();
            using (var fs = new FileStream(destinationFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite)){                
                fs.Write(buffer, (int)offset, (int)length);
            }
            var bytes = new byte[45];
            for (var i = 0; i < 45; i++){
                bytes[i] = buffer[i];
            }
            ModifyHeaderDataLength(destinationFile, 0, bytes);
        }
        private static void ModifyHeaderDataLength(string filename, int position, byte[] data){
            using (Stream stream = File.Open(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                stream.Position = position;
                stream.Write(data, 0, data.Length);
            }
        }
