    public Point getAllusrs (int myID)
    {
        Point pnt = null; // or new Point ();
        DataClasses1DataContext data = new DataClasses1DataContext();
        var a = (from s in data.Tabs where s.u1ID == myID && s.status == true select s.u2ID).ToArray();
        int inc = 0;
        foreach (var d in data.Users)
        {
            if (a[inc] != null && d.Id == a[inc])
            {
                inc++;
                pnt = new Point() { Lat = d.usrLat, Lon = d.usrLong };
            }
            else inc++;
        }  
 
        return pnt;   
    } 
