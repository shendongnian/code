    StreamWriter sw = new StreamWriter(YOUFILEPATHSTRING);
    try
    {
     foreach(KeyValuePair kvp in set_names)
     {
       sw.WriteLine(kvp.Key +";"+kvp.Value;
     }
     sw.Close();
    }
    catch (IOException ex)
    {
     sw.Close();
    }
