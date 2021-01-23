    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Linq;
    
    namespace ConvertIntToHashCodeConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                int number = 100;
                Console.WriteLine(GetHashMD5(number.ToString()));
                Console.WriteLine(GetHashStringFromInteger(number));
                Console.Read();
            }
            /// <summary>
            /// Get the Hash Value for MD5 Hash(32 Characters) from an integer
            /// </summary>
            /// <param name="number"></param>
            /// <returns></returns>
            public static string GetHashStringFromInteger(int number)
            {
                string hash;
                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    hash = String.Concat(md5.ComputeHash(BitConverter
                      .GetBytes(number))
                      .Select(x => x.ToString("x2")));
                }
                return hash;
            }
    
            /// <summary>
            /// Get the Hash Value for sha256 Hash(64 Characters)
            /// </summary>
            /// <param name="data">The Input Data</param>
            /// <returns></returns>
            public static string GetHash256(string data)
            {
                string hashResult = string.Empty;
    
                if (data != null)
                {
                    using (SHA256 sha256 = SHA256Managed.Create())
                    {
                        byte[] dataBuffer = Encoding.UTF8.GetBytes(data);
                        byte[] dataBufferHashed = sha256.ComputeHash(dataBuffer);
                        hashResult = GetHashString(dataBufferHashed);
                    }
                }
                return hashResult;
            }
    
            /// <summary>
            /// Get the Hash Value for MD5 Hash(32 Characters)
            /// </summary>
            /// <param name="data">The Input Data</param>
            /// <returns></returns>
            public static string GetHashMD5(string data)
            {
                string hashResult = string.Empty;
                if (data != null)
                {
                    using (MD5 md5 = MD5.Create())
                    {
                        byte[] dataBuffer = Encoding.UTF8.GetBytes(data);
                        byte[] dataBufferHashed = md5.ComputeHash(dataBuffer);
                        hashResult = GetHashString(dataBufferHashed);
                    }
                }
                return hashResult;
            }
            /// <summary>
            /// Get the Encrypted Hash Data
            /// </summary>
            /// <param name="dataBufferHashed">Buffered Hash Data</param>
            /// <returns> Encrypted hash String </returns>
            private static string GetHashString(byte[] dataBufferHashed)
            {
                StringBuilder sb = new StringBuilder();
                foreach (byte b in dataBufferHashed)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
