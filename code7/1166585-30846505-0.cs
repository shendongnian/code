	var csvlines = File.ReadAllLines(filename);   // IEnumerable<string>
	
    //var csvLinesData = csvlines.Select(l => l.Split(',').Skip(1).ToArray());  // IEnumerable<string[]>	
	// Instead of skipping the first column, skip the first line!
	var csvLinesData = csvlines.Skip(1).Select(l => l.Split(',').ToArray());  // IEnumerable<string[]>
	
    int flag = 0;
    var users = csvLinesData.Select(data => new User
    {
        CSRName = data[6],
        CallStart = data[0],
        CallDuration = data[1],
        RingDuration = data[2],
        Direction = data[3],
        IsInternal = data[4],
        Continuation = data[5],
        ParkTime = data[7]
    }).ToList();
