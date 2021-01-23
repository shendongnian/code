       static public string get_signature(int sk, string time, string URI, bool first_call)
        {
            string input = "";
            if (first_call)
            {
                sk %= 256;
                input = sk + time + URI;
            }
            else
            {
                sk = neo_secretkey(sk);
                sk %= 256;
                input = sk + time + URI;
            }
            //signature = the Message-Digest (MD5) of the 'secret_key' modulo 256 + 'time' + the URI of the API call. 
            byte[] ByteData = Encoding.ASCII.GetBytes(input);
            //MD5 creating MD5 object.
            MD5 oMd5 = MD5.Create();
            //Hash 
            byte[] HashData = oMd5.ComputeHash(ByteData);
            //convert byte array to hex format
            StringBuilder oSb = new StringBuilder();
            for (int x = 0; x < HashData.Length; x++)
            {
                //hexadecimal string value
                oSb.Append(HashData[x].ToString("x2"));
            }
            return oSb.ToString();
        }
