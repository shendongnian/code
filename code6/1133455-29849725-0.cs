    // Name changed to comply with .NET naming conventions
    public string GetName(uint offset, byte[] buffer)
    {
        PS3.GetMemory(offset, buffer);
        return Encoding.ASCII.GetString(buffer);
    }
