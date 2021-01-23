    string input = "08/23/2016~08:00 - 12:00~D";
    string datePart = input.Split('~')[0].Trim();
    DateTime dt;
    if (DateTime.TryParse(datePart, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out dt))
    {
        string output = dt.ToString("dddd,MMMM dd,yyyy", DateTimeFormatInfo.InvariantInfo);
    }
