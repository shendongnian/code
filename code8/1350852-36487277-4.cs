    int length, width, height, totalDims;
		
    Console.Write("Enter your Length: ");
	// Read and parse your length
	while(!Int32.TryParse(Console.ReadLine(), out length)){
		Console.Write("Enter your Length again: ");
	}
		
	Console.Write("Enter your Width: ");
	// Read and parse your width
	while(!Int32.TryParse(Console.ReadLine(), out width)){
		Console.Write("Enter your Width again: ");
	}
		
	Console.Write("Enter your Height: ");
	// Read and parse your height
	while(!Int32.TryParse(Console.ReadLine(), out height)){
		Console.Write("Enter your Height again: ");
	}
		
	// Now you have all of your dimensions so calculate
	totalDims = length * width * height;
	// Since you are performing division, you could have a fractional
	// value here, so you might want to use another type like decimal
	decimal cubicFeet = totalDims / 1728m;
	// Output your result
	Console.WriteLine("Your total cubic feet is " + cubicFeet);
