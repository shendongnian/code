    System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-us");
    string date = "Fri May 06 2016 06:00:00 GMT+0600 (Azores Standard Time)";
    DateTime DT = DateTime.Parse(date.Split('G')[0]);
    string value = DT.ToString("MM/dd/yyyy HH:mm tt", ci);
    MessageBox.Show(value);
