    private static void worker_DoWork(object sender, DoWorkEventArgs e)
            {
                Tuple<int, byte[]> t = e.Argument as Tuple<int, byte[]>;
    
                int blockIndex = (int)t.Item1;
                byte[] inBuffer = (byte[])t.Item2;
                byte[] outBuffer;
               
                //using keyword will automatically close the stream
    
                using (MemoryStream outStream = new MemoryStream()) // issue may be here?
                {
                    AesCryptoServiceProvider RMCrypto = new AesCryptoServiceProvider();
    
                    using (CryptoStream cs = new CryptoStream(outStream,
                                      RMCrypto.CreateEncryptor(key, key),
                                      CryptoStreamMode.Write))
                    {
                        // I want to write inbuffer non encrypted to outbuffer encrypted.
                        cs.Write(inBuffer, blockIndex, inBuffer.Length);
                        
                    }
                        outBuffer = outStream.ToArray();
                 }
    
                e.Result = Tuple.Create(blockIndex, outBuffer);
            }
