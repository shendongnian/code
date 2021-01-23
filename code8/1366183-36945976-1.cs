    public string EncodePassword(string pass, 
        MembershipPasswordFormat passwordFormat, string salt)
    {
        byte[] numArray;
        byte[] numArray1;
        string base64String;
    
        if (passwordFormat == MembershipPasswordFormat.Hashed)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] numArray2 = Convert.FromBase64String(salt);
            byte[] numArray3;
    
            // Hash password
            HashAlgorithm hashAlgorithm = HashAlgorithm.Create(Membership.HashAlgorithmType);
    
            if (hashAlgorithm as KeyedHashAlgorithm == null)
            {
                numArray1 = new byte[numArray2.Length + bytes.Length];
                Buffer.BlockCopy(numArray2, 0, numArray1, 0, numArray2.Length);
                Buffer.BlockCopy(bytes, 0, numArray1, numArray2.Length, bytes.Length);
                numArray3 = hashAlgorithm.ComputeHash(numArray1);
            }
            else
            {
                KeyedHashAlgorithm keyedHashAlgorithm = (KeyedHashAlgorithm)hashAlgorithm;
    
                if (keyedHashAlgorithm.Key.Length != numArray2.Length)
                {
    
                    if (keyedHashAlgorithm.Key.Length >= numArray2.Length)
                    {
                        numArray = new byte[keyedHashAlgorithm.Key.Length];
                        int num = 0;
                        while (true)
                        {
                            if (!(num < numArray.Length))
                            {
                                break;
                            }
                            int num1 = Math.Min(numArray2.Length, numArray.Length - num);
                            Buffer.BlockCopy(numArray2, 0, numArray, num, num1);
                            num = num + num1;
                        }
                        keyedHashAlgorithm.Key = numArray;
                    }
                    else
                    {
                        numArray = new byte[keyedHashAlgorithm.Key.Length];
                        Buffer.BlockCopy(numArray2, 0, numArray, 0, numArray.Length);
                        keyedHashAlgorithm.Key = numArray;
                    }
                }
                else
                {
                    keyedHashAlgorithm.Key = numArray2;
                }
                numArray3 = keyedHashAlgorithm.ComputeHash(bytes);
            }
    
            base64String = Convert.ToBase64String(numArray3);
        }
        else if (passwordFormat == MembershipPasswordFormat.Encrypted)
        {
            throw new NotImplementedException("Encrypted password method is not supported.");
        }
        else
        {
            base64String = pass;
        }
    
        return base64String;
    }
