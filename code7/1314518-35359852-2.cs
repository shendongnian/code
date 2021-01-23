    private string decrypt(String encrypted)
    {
        byte[] bytes = Convert.FromBase64String(Treasure); // here
        return System.Text.Encoding.Unicode.GetString(bytes);
    }
