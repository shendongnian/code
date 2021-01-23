    static string GetMd5PerlishString(MD5 md5Hash, string input)
        {
    
            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
    
            string result = System.Text.Encoding.UTF8.GetString(data);
           
            return result;
        }
