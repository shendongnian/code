    // This is an array of strings right?
    string[,] array=new string[,]{{"2000","2"},{"2001","4"}};
        
    // Use a StringBuilder to accumulate your output
    StringBuilder sb = new StringBuilder("Date;C1\r\n");
    for (int i = 0; i <= array.GetUpperBound(0); i++)
    {
        for (int j = 0; j <= array.GetUpperBound(1); j++)
        {
             sb.Append((j==0 ? "" : ";") + array[i, j]);        
        }
        sb.AppendLine();
    }
    // Write everything with a single command 
    File.WriteAllText(@"fileadress.csv", sb.ToString());
