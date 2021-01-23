    for (int i = 0; i < dt.Rows.Count; ) // do not increment here
    {
        string duration = dt.Rows[i][1].ToString();
        
        if (duration == "")
        {
            dt.Rows[i].Delete();
        }
        else
            i += 1; // ... but increment here 
        Console.WriteLine(i.ToString() + dt.Rows[i][1].ToString());
    }
