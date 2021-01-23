    class gItem
    {
        DateTime StartDate{ get; set; }
        DateTime EndDate{ get; set; }
        int LineNumber{ get; set; }
        int Length { get { return EndDate - StartDate; } }
        //some other code and stuff you'd like to add
    }
