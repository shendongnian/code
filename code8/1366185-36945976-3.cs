    private string EncodePassword(string pass, int passwordFormat, string salt)
    { 
        if (passwordFormat == 0) // MembershipPasswordFormat.Clear
            return pass;
    
        byte[] bIn = Encoding.Unicode.GetBytes(pass); 
        byte[] bSalt = Convert.FromBase64String(salt);
        byte[] bRet = null; 
     
        if (passwordFormat == 1)
        { // MembershipPasswordFormat.Hashed 
            HashAlgorithm hm = GetHashAlgorithm();
            if (hm is KeyedHashAlgorithm) {
                KeyedHashAlgorithm kha = (KeyedHashAlgorithm) hm;
                if (kha.Key.Length == bSalt.Length) { 
                    kha.Key = bSalt;
                } else if (kha.Key.Length < bSalt.Length) { 
                    byte[] bKey = new byte[kha.Key.Length]; 
                    Buffer.BlockCopy(bSalt, 0, bKey, 0, bKey.Length);
                    kha.Key = bKey; 
                } else {
                    byte[] bKey = new byte[kha.Key.Length];
                    for (int iter = 0; iter < bKey.Length; ) {
                        int len = Math.Min(bSalt.Length, bKey.Length - iter); 
                        Buffer.BlockCopy(bSalt, 0, bKey, iter, len);
                        iter += len; 
                    } 
                    kha.Key = bKey;
                } 
                bRet = kha.ComputeHash(bIn);
            }
            else {
                byte[] bAll = new byte[bSalt.Length + bIn.Length]; 
                Buffer.BlockCopy(bSalt, 0, bAll, 0, bSalt.Length);
                Buffer.BlockCopy(bIn, 0, bAll, bSalt.Length, bIn.Length); 
                bRet = hm.ComputeHash(bAll); 
            }
        } else { 
            byte[] bAll = new byte[bSalt.Length + bIn.Length];
            Buffer.BlockCopy(bSalt, 0, bAll, 0, bSalt.Length);
            Buffer.BlockCopy(bIn, 0, bAll, bSalt.Length, bIn.Length);
            bRet = EncryptPassword(bAll, _LegacyPasswordCompatibilityMode); 
        }
     
        return Convert.ToBase64String(bRet); 
    }
