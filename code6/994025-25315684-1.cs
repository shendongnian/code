    private string HashHelper(string query)
    {
        using (SHA256Managed hashEngine = new SHA256Managed())
        {
            byte[] data = hashEngine.ComputeHash(Encoding.UTF8.GetBytes(query));
            StringBuilder hash = new StringBuilder(64);
            for (int i = 0; i < data.Length; i++)
            {
                hash.Append(data[i].ToString("x2"));
            }
            return hash.ToString();
        }
               
    }
