    public string ArrayToString(int[,] toConvert)
    {
        StringBuilder sb = new StringBuilder();
        for (int a = 0; a < toConvert.GetLength(0);a++)
        {
            for (int b = 0; b < toConvert.GetLength(1);b++)
            {
                sb.Append(toConvert[a,b].ToString() + ",");
            }
    
            sb.Append(".");
        }
    
        return sb.ToString();
    }
