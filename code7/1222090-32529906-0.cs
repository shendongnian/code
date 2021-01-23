    public long ConvertDataSize(string str)
    {
        string[] parts = str.Split(' ');
        if (parts.Length != 2)
            throw new Exception("Unexpected input");
        var number_part = parts[0];
        double number = Convert.ToDouble(number_part);
        var unit_part = parts[1];
        var bytes_for_unit = GetNumberOfBytesForUnit(unit_part);
        return Convert.ToInt64(number*bytes_for_unit);
    }
    private long GetNumberOfBytesForUnit(string unit)
    {
        if (unit.Equals("kb", StringComparison.OrdinalIgnoreCase))
            return 1024;
        if (unit.Equals("mb", StringComparison.OrdinalIgnoreCase))
            return 1048576;
        if (unit.Equals("gb", StringComparison.OrdinalIgnoreCase))
            return 1073741824;
        if (unit.Equals("bytes", StringComparison.OrdinalIgnoreCase))
            return 1;
        //Add more rules here to support more units
        throw new Exception("Unexpected unit");
    }
