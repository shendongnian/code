    public static byte[] CreatePasswordHash(string password, byte[] salt, int iterations = 60000)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            // step 2
            byte[] hash = sha256.ComputeHash(ConcatArrays(passwordBytes, salt));
            // step 3
            byte[] result = sha256.ComputeHash(ConcatArrays(salt, hash));
            // step 4
            for (int i = 0; i < iterations; i++)
            {
                result = sha256.ComputeHash(ConcatArrays(salt, result));
            }
            return result;
        }
    }
