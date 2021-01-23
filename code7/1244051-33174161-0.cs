    var sb = new StringBuilder();
    foreach (RepeaterItem rpItems in rpGetData.Items)
    {
        RadioButtonList rbYesNo = (RadioButtonList)rpItems.FindControl("rbBadge");
        if (rbYesNo.SelectedItem.Text == "Yes")
        {
            // ..omitted..
            sb.WriteLine("Name," + Name);
            sb.WriteLine("Company," + Company);
            sb.WriteLine("Date," + Date);
            sb.WriteLine("*PRINTLABEL");
        }
    }
    if (sb.Length > 0)
    {
        File.WriteAllText(FileName, sb.ToString());
    }
