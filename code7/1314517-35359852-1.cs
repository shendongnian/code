    private string decrypt(String encrypted)
    {
        byte[] bytes = Convert.FromBase64String(Treasure);
        return System.Text.Encoding.Unicode.GetString(bytes);
    }
