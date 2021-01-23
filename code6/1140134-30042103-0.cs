    public void BindStates(DataTable states)
    {
        int numberUsa = 0;
        foreach (DataRow row in states.Rows)
        {
            if (row[1].ToString() == "USA")
            {
                numberUsa++;
            }
        }
        Console.WriteLine(numberUsa.ToString());
    }
