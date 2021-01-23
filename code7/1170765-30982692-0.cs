    DateTime dateTime;
    if (DateTime.TryParseExact(txtData.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
    {
        //conversion succeeded, you date is in dateTime var
    }
    else
    {
        //conversion failed
    }
