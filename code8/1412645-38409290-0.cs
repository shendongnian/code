         //using (MemoryStream memoryStream = new MemoryStream())
            //{
            //    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, tdes.CreateEncryptor(keyArray, keyArray), CryptoStreamMode.Write))
            //    {
            //        using (StreamWriter writer = new StreamWriter(cryptoStream))
            //        {
            //            writer.Write(toEncrypt);
            //            cryptoStream.FlushFinalBlock();
            //            writer.Flush();
            //            retvalue = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length).Replace("-", "");
            //            writer.Close();
            //        }
            //        cryptoStream.Close();
            //    }
            //    memoryStream.Close();
            //}
            //return retvalue;
            ICryptoTransform ct = tdes.CreateEncryptor();
            byte[] input = Encoding.UTF8.GetBytes(toEncrypt);
            var output = ct.TransformFinalBlock(input, 0, input.Length);
            return Convert.ToBase64String(output);
