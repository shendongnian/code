    private void destination()
    {
        if (rbUK.Checked)
        {
            // Read all the lines in a single call, 
            string[] lines = File.ReadAllLines(@".\Debug\PostageCosts.csv");
            // I expect to have three lines but better to check before acting on the array
            if(lines.Length > 0)
            {
                // Split the line for UK and use only the first 6 values
                // for the list (the last strings 'per kg  UK' should not be added)
                // Again, at least 6 decimal values are expected not less...
                var values = lines[0].Split(',');
                if(values.Length >= 6)
                    for(int x = 0; x < 6; x++)
                        UK.Add(decimal.Parse(values[x]));
            }
            if(lines.Length > 1)
            {
                var values = lines[1].Split(',');
                if(values.Length >= 6)
                    for(int x = 0; x < 6; x++)
                        RestOfEurop.Add(decimal.Parse(values[x]));
            }
            if(lines.Length > 2)
            {
                var values = lines[2].Split(',');
                if(values.Length >= 6)
                    for(int x = 0; x < 6; x++)
                        WorlWide.Add(decimal.Parse(values[x]));
            }
            // Test what list to display passing the index 0,1,2
            int listToShow = 0;
            display(listToShow);
        }
    }
    public void display(int listToShow)
    {
        List<decimal> showList = (listToShow == 0 ? UK : 
                                  listToShow == 1 ? RestOfEurope : 
                                                    WorlWide);
        label2.Text = string.Join("-",  showList.ToArray());
    }
