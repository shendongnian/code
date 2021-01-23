    public class HmacSha256
    {
        public byte[] Hash(string text, string key)
        {
            var hmac = new HMac(new Sha256Digest());
            hmac.Init(new KeyParameter(Encoding.UTF8.GetBytes(key)));
            byte[] result = new byte[hmac.GetMacSize()];
            byte[] bytes = Encoding.UTF8.GetBytes(text);
                
            hmac.BlockUpdate(bytes, 0, bytes.Length);
            hmac.DoFinal(result, 0);
                
            return result;
        }
    }
