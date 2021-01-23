    public class HmacSha256
        {
            private readonly HMac _hmac;
    
            public HmacSha256(byte[] key)
            {
                _hmac = new HMac(new Sha256Digest());
                _hmac.Init(new KeyParameter(key));
            }
    
            public byte[] ComputeHash(byte[] value)
            {
                if (value == null) throw new ArgumentNullException("value");
    
                byte[] resBuf = new byte[_hmac.GetMacSize()];
                _hmac.BlockUpdate(value, 0, value.Length);
                _hmac.DoFinal(resBuf, 0);
    
                return resBuf;
            }
        }
