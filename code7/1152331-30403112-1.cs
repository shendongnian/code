    class Shop
    {
    //public string name; //This one should have getters and setters too, fields shouldn't be exposed.
    public string Name { get; set; }
    public DayOfWeek Day{ get; set; }
    public TimeSpan Start{ get; set; }
    public TimeSpan End{ get; set; }
    public string Address{ get; set; }
    public string Category{ get; set; }
    public Shop(string name, DayOfWeek day, TimeSpan start, TimeSpan end, string address, string category)
        {
        this.Name = name;
        this.Day = day;
        this.Start = start;
        this.End = end;
        this.Address = address;
        this.Category = category;
        }
    }
