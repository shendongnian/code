    var Segment = Request.GetFriendlyUrlSegments().ToList();
    if (Segment.Count <= 0)
    {
        return;
    }
    
    string param1 = Segment[0].ToString();
    string param2 = Segment[1].ToString();
