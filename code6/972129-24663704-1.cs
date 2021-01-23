    public int SelectedInterval {get;set;}
    public List<int> Intervals {
        get {
            var lst = new List<int>();
            for(var i = 1000; i <= 10000; i += 500)
            {
                lst.Add(i);
            }
            return lst;
        }
    }
