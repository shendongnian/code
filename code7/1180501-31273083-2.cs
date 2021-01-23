    using (var sr = new StreamReader(fullFileName))
    {
        // read the first 4 lines but do nothing with them; basically, skip them
        for (int i=0; i<4; i++)
            sr.ReadLine();
        string line1;
        while ((line1 = sr.ReadLine()) != null) //Will skip the first 4 then rewrite the file
        {
            sb.AppendLine(line1);
        }
    }
