    var lines = System.IO.File.ReadAllLines("C:\\temp\\numbers.txt");
    
    var lineArray = lines.Select(x =>
    {
    	var numbers = x.Split(' ');
    	//do stuff with individual numbers here.
    	return string.Join(" ", numbers);
    }
    );
    
    System.IO.File.WriteAllLines("C:\\temp\\txt.txt", lineArray);
