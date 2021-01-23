    DateTime taskDate;
    if (DateTime.TryParseExact(txtDate.Text, "dd-MM-yyyy hh:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDate))
    {
        //code if date valid
    }
    else
    {
        //code if date invalid
    }
