    int flag = 0;
    try
    {
        using (StreamReader reader = new StreamReader(FileName, Encoding.GetEncoding("iso-8859-1"), true))
        {
            flag = 1;
            reader.ReadToEnd();
            flag = 2;
        }
        flag = int.MaxValue;
    }
    catch (Exception ex)
    {
    }
    if (flag == 0)
    {
        // Exception on opening
    }
    else if (flag == 1)
    {
        // Exception on reading
    }
    else if (flag == 2)
    {
        // Exception on closing
    }
    else if (flag == int.MaxValue)
    {
        // Everything OK
    }
