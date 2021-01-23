    class Point
    {
        public string Lat {get;set;}
        public string Lon {get;set}
    }
    public Point getUsrLocation(string uName)
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        return (from s in data.Users where s.usrName == uName select new Point(){Lat=s.usrLat,Lon=s.usrLong}).Single();
    }
