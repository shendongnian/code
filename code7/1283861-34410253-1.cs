    DateTime myDate = DateTime.ParseExact(TextBoxStartDate.Text, "dd-MM-yyyy",
             System.Globalization.CultureInfo.InvariantCulture);
    int numVal = Int32.Parse(TextBoxPredictDays.Text);
    myDate.AddDays(numVal);
    
