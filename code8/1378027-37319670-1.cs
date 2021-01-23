    string bgColour = "";
    for (int i = 0; i < line.Length; i++)
    {
        string[] col = line[i].Split(new string[] { "," }, StringSplitOptions.None);
    
        csvList.Add(new CSVEntry() { date = DateTime.ParseExact(col[7], "dd/MM/yyyy", null) });
    }
    var dates = csvList.OrderBy(x => x.date).Select(x => x.date);
    foreach (DateTime dueDate in dates)
    {
        if (dueDate == DateTime.Today)
        {
            // if due date is today, blue
            bgColour = "40FFFF";
        }
        else if (dueDate > DateTime.Today)
        {
            // if due date is not today yet, white
            bgColour = "FFFFFF";
        }
        else
        {
            // if due date has passed, yellow
            bgColour = "FFFF40";
        }
    }
