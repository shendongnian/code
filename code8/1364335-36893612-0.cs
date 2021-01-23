    private void AddDataToDataTable()
    {
        using (StreamReader sr = new StreamReader(new MemoryStream(this.FileContents)))
        {
            //Igone headings & blank Lines
            string line = string.Empty;
            while ((line = sr.ReadLine()) != null)
            {
                //If blank line then skip line
                if (line == string.Empty) 
                {
                    continue;
                }
                dt.Rows.Add(line.Split(this.Delimeter));
            }
        }
    }
