    private byte[] ToBytes(string message)
    {
        return Encoding.UTF8.GetBytes(message);
    }
    
    private string ToString(byte[] bytes)
    {
        return Encoding.UTF8.GetString(bytes);
    }
