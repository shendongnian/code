                    using (ZipOutputStream stream = new ZipOutputStream (File.Create (_outputPathName))) 
                    {
                        stream.SetLevel(9); //设置压缩等级0-9
                        byte[] buffer = new byte[4096];                    
                        var entry = new ZipEntry(Path.GetFileName(_filePathName));
                        entry.DateTime = DateTime.Now;
                        entry.Flags |= (int)GeneralBitFlags.UnicodeText;
                        stream.PutNextEntry(entry);
                        using (FileStream fs = File.OpenRead(_filePathName)) 
                        {
                            int sourceBytes;
                            do 
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                stream.Write(buffer, 0, sourceBytes);
                            } 
                            while (sourceBytes > 0);
                        }
                        stream.Finish();
                        stream.Close();
                    }
