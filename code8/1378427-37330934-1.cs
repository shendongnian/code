    if (!double.TryParse(parsedText, out measurment))
    {
        string measurmentString = Regex.Match(parsedText, @"\d+\.?\d+").Value;
        if (double.TryParse(measurmentString , out measurment))
        { 
        }
    }
