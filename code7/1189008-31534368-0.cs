    public string StripPortFromEndPoint(string endPoint)
    {
        var splitList = endPoint.Split(':');
        if (splitList.Length > 2)
        {
            endPoint = IPAddress.Parse(endPoint).ToString();
        }
        else if (splitList.Length == 2)
        {
            endPoint = splitList[0];
        }
        else
        {
            throw new ParseException("No port separator found",0);
        }
            
        return endPoint;
    }
