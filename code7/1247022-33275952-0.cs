            string EncryptedStr = string.Empty;
            Encoding encode1 = Encoding.Default; //.ASCII;
            Byte[] encodedBytes = encode1.GetBytes("Test@1234");
            for (int count = 0; count < encodedBytes.Length; count++)
            {
                int str1 = encodedBytes[count] - 1;
                Encoding encode2 = Encoding.Default;
                Byte[] encodedBytes1 = encode2.GetBytes((count + 1).ToString());
                int str2 = str1 + (int)encodedBytes1[0];
                EncryptedStr += Convert.ToChar(str2);
            }
