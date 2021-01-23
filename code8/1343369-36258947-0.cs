    public string Devices { get; set; }
    List<int> innerList;
    public List<int> List
    {
        get
        {
            if (this.innerList == null)
            {
                if (string.IsNullOrEmpty(this.Devices))
                {
                    this.innerList = this.Devices.Split(',').Select(x => int.Parse(x)).ToList();
                }
                else
                {
                    this.innerList = new List<int>();
                }
            }
    
            return this.innerList;
        }
    }
