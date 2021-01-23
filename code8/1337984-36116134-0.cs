    public static Byte[] GetBytes(string binary)
            {
                int numOfBytes = binary.Length / 8;
                byte[] bytes = new byte[numOfBytes];
                for (int i = 0; i < numOfBytes; ++i)
                {
                    bytes[i] = Convert.ToByte(binary.Substring(8 * i, 8), 2);
                }
    
                return bytes;
            }
