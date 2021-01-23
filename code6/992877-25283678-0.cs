    //this variable is for saving results
    Dictionary<int,double> memberLengthMap = new Dictionary<int,double>();
    
    Dictionary<int, Tuple<double, double, double>> nodes = GetNodeID_AlongWithCoordinates();
    Dictionary<int, Tuple<int,int>> members = GetMemberID_AlongWithStartandEndNode();
    foreach(KeyValuePair<int, Tuple<int,int>> member in members)
    {
    	Tuple<double, double, double> startNode = nodes[member.Value.Item1];
    	Tuple<double, double, double> endNode = nodes[member.Value.Item2];
    	double xDiff = (startNode.Item1 - endNode.Item1);
    	double yDiff = (startNode.Item2 - endNode.Item2);
    	double zDiff = (startNode.Item3 - endNode.Item3);
    	
    	double distance = Math.Sqrt(xDiff*xDiff + yDiff*yDiff + zDiff*zDiff);
    	memberLengthMap.put(member.Key,distance);
    }
