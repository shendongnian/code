    using System.Security.Cryptography;
    
        class Program
        {
            static void Main(string[] args)
            {
                string StrPassword = "Push@123";
                using (MD5 md5Hash = MD5.Create())
                {
                    string hashPassword = GetMd5Hash(md5Hash, StrPassword);
    				Console.WriteLine(hashPassword);
    			}
    		}
			static string GetMd5Hash(MD5 md5Hash, string input)
			{
				byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
				StringBuilder sBuilder = new StringBuilder();
				for (int i = 0; i < data.Length; i++)
				{
					sBuilder.Append(data[i].ToString("x2"));
				}
				return sBuilder.ToString();
			}
    	}
