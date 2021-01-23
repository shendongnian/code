    public static void Main()
    {
        myFunction(new Dictionary<string, object>()
            {
                { "meetingID", 2},
                { "meetingRoom", "A103"}
            }
        );
    }
    public static void myFunction(Dictionary<string,object> args)
    {
        var x = args["meetingID"];
    }
