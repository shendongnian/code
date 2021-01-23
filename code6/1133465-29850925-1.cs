    public static byte[] AesEncrypt(string toEncrypt, byte[] key)
    {
        byte[] output = new byte[0];
        var data = Encoding.UTF8.GetBytes(toEncrypt);
        
        Console.WriteLine("Data: {0}", Encoding.ASCII.GetString(data));
        Console.WriteLine("Key: {0}", BitConverter.ToString(key));
        using (AesCryptoServiceProvider acp = new AesCryptoServiceProvider())
        {
            acp.GenerateIV();
            byte[] vector = acp.IV;
            using (ICryptoTransform trans = acp.CreateEncryptor(key, vector))
            {
                Console.WriteLine("Vector: {0}", BitConverter.ToString(vector));
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, trans, CryptoStreamMode.Write))
                    //using (BinaryWriter bw = new BinaryWriter(cs))
                    {
                        cs.Write(data, 0, data.Length);
                        //bw.Write(vector);
                        //bw.Write(data);
                        cs.FlushFinalBlock();
                        output = ms.ToArray();
                    }
                }
            }
        }
        Console.WriteLine("Output: {0}", BitConverter.ToString(output));
        return output;
    }
