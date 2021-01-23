    string final = string.Empty;
    string name = encoder.GetString(buffer);
    char []arr = name.ToArray();
    
    boolean bln = true;
    foreach (char item in arr)
    {
        if (bln)
        {
            if (item == '}')
            {
                final += item.ToString();
                break;
            }
            else
            {
                final += item.ToString();
            }
        }
    }
    
    Console.WriteLine(final);
