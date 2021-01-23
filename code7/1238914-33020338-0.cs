    double AsDouble(string input)
    {
        switch (input)
        {
            case "TRUE": return 1.0;
            case "FALSE": return 0.0;
         
            //any other special cases
            default: return Convert.ToDouble(input); //may still throw!
        }
    }
