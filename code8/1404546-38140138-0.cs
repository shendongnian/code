    private byte[] String_To_Bytes2(string strInput)
                {
                    int numBytes = (strInput.Length) / 2;
                    byte[] bytes = new byte[numBytes];
        
                    for (int x = 0; x < numBytes; ++x)
                    {
                        bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
                    }
                    return bytes;
                }
    static void Main(string[] args)
            {
                string tmp = "40FA";
                int uid_1 = Convert.ToInt32(tmp.Substring(0, 2), 16);
                int uid_2 = Convert.ToInt32(tmp.Substring(2, 2), 16);
                int test = uid_1 ^ uid_2;
                string final = test.ToString("X");
                byte[] toBytes = String_To_Bytes2(final);
    
                Console.WriteLine(toBytes);
                Console.ReadKey();
            }
