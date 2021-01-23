    int ID_COLUMN = 2;
    for(int i = 0; i < xlsDs.Rows.Count; i++)
    {
        // get the current row
        DataRow row = xlsDs.Rows[i];
        // get the ID from the row
        string idValue = ((Excel.Range)row.Cells[i, ID_COLUMN]).Value2.ToString();
        // Check the ID from the row to make sure it is valid?
        Match match = Regex.Match(idValue, @".*[0-9].*");
        // check if the row value is equal to the textbox entry
        bool myMatch = idValue.Equals(textBox3.Text);
        // if both of the above are true, do this
        if (match.Success && myMatch == true)
        {
            Console.Write(idValue);
            Console.WriteLine(" -This id was found");
        }
    }
