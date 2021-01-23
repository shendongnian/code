     protected string Format_Number(string Number)
     {
        // Variable
        string value = string.Empty;
        decimal castValue = 0;
        bool isValid = false;
        // Check
        if (Number != string.Empty)
        {
            // Parse
            isValid = decimal.TryParse(Number, out castValue);
            // Check & Set Decimal Valud
            if (isValid) value = castValue.ToString("0,0");
        }
        return value;
     }
