	var dic = new Dictionary<Point,Point>();
	dic.Add(new Point(1,1), new Point(1,2));
	
	var f = dic[new Point(1,1)];
	Console.WriteLine(f.x); //Output will be 1
    
		
