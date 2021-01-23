    for(int i=0;i<split.Length;i++)
    {
        string val = split[i].Trim(); //Get rid of white space
        val = val.Replace("\r\n","");  //Use one of these to trim every character.
        val = val.Replace("\n","");
        try
        {
            elements.Add(Convert.ToInt32());
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            //You might try formatting the split value even more here and retry convert
        }
        
    }
