    var sb = new StringBuilder();
    foreach (RepeaterItem rpItems in rpGetData.Items)
    {
        RadioButtonList rbYesNo = (RadioButtonList)rpItems.FindControl("rbBadge");
        if (rbYesNo.SelectedItem.Text == "Yes")
        {
            // ..omitted..
            sb.AppendLine("Name," + Name);
            sb.AppendLine("Company," + Company);
            sb.AppendLine("Date," + Date);
            sb.AppendLine("*PRINTLABEL");
        }
    }
    if (sb.Length > 0)
    {
        File.WriteAllText(FileName, sb.ToString(), Encoding.GetEncoding(1250));
    }
