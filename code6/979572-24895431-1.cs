    enum StatusCode
    {
       Open,
       Received,
       Delivered,
       Cancelled
    }
    private Dictionary<StatusCode, int> storedCodes = new Dictionary<StatusCode, int>();
    public static int GetValue(StatusCode code)
    {
        //Return code from database
        return storedCodes[code];
    }
    public static void SetValue(StatusCode code, int value)
    {
        storedCodes[code] = value;
        //Set values from database
        //Note:  you can't set the value of your enums here
        //Just a place to set some other variables to remember what the values are.
    }
