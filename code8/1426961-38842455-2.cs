    private OleDbParameter CreateOleDbParameter(string parameterName, string parameterValue)
    {
        double output = 0;
        if (double.TryParse(parameterValue, out output))
        {
            return new OleDbParameter(parameterName, output);
        }
        else
        {
            return new OleDbParameter(parameterName, DBNull.Value);
        }
    }
