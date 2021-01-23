    string columnName = "Employee ID"; // change to the correct header
    // Check the ID from the textbox to make sure it is valid?
    Match match = Regex.Match(textBox3.Text @".*[0-9].*");
    for(int i = 0; i < xlsDs.Rows.Count; i++)
    {
        // get the current row
        DataRow row = xlsDs.Rows[i];
        // get the ID from the row
        string idValue = row[columnName].ToString();
        // check if the row value is equal to the textbox entry
        bool myMatch = idValue.Equals(textBox3.Text);
        // if both of the above are true, do this
        if (match.Success && myMatch == true)
        {
            Console.Write(idValue);
            Console.WriteLine(" -This id was found");
        }
    }
