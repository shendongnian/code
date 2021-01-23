    public string takeOutSpaces(string data)
    {
       string result = data;
       result = result.Replace("\r", "");
       result = result.Replace("\n", "");
       result = result.Replace("\t", "");
       return result;
    }
