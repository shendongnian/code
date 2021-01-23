    public static string CreateEntryHash(Guid warrantyId, bool hasColor, Guid? colorId, bool hasSize, Guid? sizeId)
    {
        var sb = new StringBuilder();
        sb.Append(warrantyId);
        sb.Append(hasColor);
        sb.Append(colorId == null ? "null" : colorId.ToString());
        sb.Append(hasSize);
        sb.Append(sizeId == null ? "null" : sizeId.ToString());
    
        var hash = GetMd5Hash(sb.ToString());
    
        return hash;
    }
    
    public static string GetMd5Hash(string input)
    {
        StringBuilder sBuilder = new StringBuilder();
        using (MD5 md5Hash = MD5.Create())
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
        }
    
        return sBuilder.ToString();
    }
    public bool IsExists(Guid warrantyId, bool hasColor, Guid? colorId, bool hasSize, Guid? sizeId)
    {
        var hash = CreateEntryHash(warrantyId, hasColor, colorId, hasSize, sizeId);
        return _products.Any(p => p.EntryHash == hash);
    }
