        public byte[] GetUID(string name)
        {            
            var bytes = Encoding.ASCII.GetBytes(name);
            if (bytes.Length > 21)
                throw new ArgumentException("Value is too long to be used as an ID");
            var uid = new byte[21];
            Buffer.BlockCopy(bytes, 0, uid, 0, bytes.Length);
            return bytes;
        }
        public string GetName(byte[] UID)
        {
            int length = UID.Length;
            
            for (int i = 0; i < UID.Length; i++)
            {
                if (UID[i] == 0)
                    length = i;
            }
            return Encoding.ASCII.GetString(UID, 0, length);
        }
