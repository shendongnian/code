    enum StatusCode
    {
       Open,
       Received,
       Delivered,
       Cancelled
    }
    public static int GetValue(StatusCode code)
    {
        //Return code from database
    }
    public static void SetValue(StatusCode code)
    {
        //Set values from database
        //Note:  you can't set the value of your enums here
        //Just a place to set some other variables to remember what the values are.
    }
