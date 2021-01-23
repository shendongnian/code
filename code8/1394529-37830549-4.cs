    // let your class have an appropriate creator
	internal Bicycle(int codeB, string name_parking_station, int km_made)
	{
		this.codeB = codeB;
		this.name_parking_station = name_parking_station;
		this.km_made = km_made;
	}
    // In your line reader loop:
    // lineRead contains the current line
    var lineParts = lineRead.Split(' ').Where(item => !string.IsNullOrWhiteSpace(item)).ToArray();        
    // lineParts now should contain 3 strings
	if(lineParts.Length == 3)
	{
		var bicycle = new Bicycle(int.Parse(lineParts[0]), lineParts[1], int.Parse(lineParts[2]));
        // add your new object to a collection of Bicycle objects
	}
