            try
            {
                string mChecksum;
                using (FileStream stream = File.OpenRead(@"E:\draft.pdf"))
                {
                    var sha = new SHA256Managed();
                    var cs = new CryptoStream(stream, sha, CryptoStreamMode.Read);
                    cs.FlushFinalBlock();
                    byte[] hash = sha.Hash;
                    mChecksum = BitConverter.ToString(hash).Replace("-", String.Empty);
                }
                Console.WriteLine(mChecksum);
            }
            catch (Exception ex)
            {
                Console.WriteLine("unable to retrieve checksum");
            }
