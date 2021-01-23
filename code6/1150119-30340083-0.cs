    public async Task<bool> CheckFile(string file, string filehash) 
    {
         await Task.Run<bool>(()=> {
            if (File.Exists(file))
            {
                using (FileStream stream = File.OpenRead(file))
                {
                    SHA1Managed sha = new SHA1Managed();
                    byte[] checksum = sha.ComputeHash(stream);
                    string sendCheckSum = BitConverter.ToString(checksum)
                        .Replace("-", string.Empty);
                   return sendCheckSum.ToLower() == filehash;
                }
            }
            else return false;
         });
    }
