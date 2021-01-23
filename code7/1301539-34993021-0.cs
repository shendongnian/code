       public static void CopyWavFile(string inPath, string outPath){
            using (var fs = File.Open(inPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)){
                using (var reader = new WaveFileReader(fs)){
                    using (var writer = new WaveFileWriter(outPath, reader.WaveFormat)){
                        reader.Position = 0;
                        var endPos = (int)reader.Length;                        
                        var buffer = new byte[1024];
                        while (reader.Position < endPos){
                            var bytesRequired = (int)(endPos - reader.Position);
                            if (bytesRequired <= 0) continue;
                            var bytesToRead = Math.Min(bytesRequired, buffer.Length);
                            var bytesRead = reader.Read(buffer, 0, bytesToRead);
                            if (bytesRead > 0){
                                writer.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }         
            }           
        }
