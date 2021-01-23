    public static List<Curve> GetData()
    {
        var data = new List<Curve>();
        var startTime = new DateTime(2016, 4, 6, 16, 1, 0);
    
        for (int i = 0; i < 4; i++)
        {
            if (i == 2)
            {
               //startTime.AddDays(1); - this line does nothing, DateTime is an immutable struct so all function changing its value returns a new copy
               startTime = startTime.AddDays(1);
            }
    
            if (i % 2 == 0)
            {
               data.Add(CreateNewCurve(startTime, 1));
            }
            else
            {
               data.Add(CreateNewCurve(startTime, 1));
               data.Add(CreateNewCurve(startTime, 2));
            }
    
            //startTime.AddMinutes(i + 1); same issue as above
            startTime = startTime.AddMinutes(i + 1);
        }
    
        return data;
    }
    
    public static Curve CreateNewCurve(DateTime time, int curveID)
    {
        return new Curve()
        {
            Timestamp = time,
            CurveID = curveID
        };
    }
