    private string decrypt(String encrypted)
    {
        byte[] bytes = Convert.FromBase64String(encrypted);
        return System.Text.Encoding.Unicode.GetString(bytes);
    }
