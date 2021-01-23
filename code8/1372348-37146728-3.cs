	// Original input
	var input = "0xaa336539";
	
	// Gets aa336539
	var inputRemovePrefix = input.Substring(2);
	
	// Converts to a long
	var numberConversion = long.Parse(inputRemovePrefix, System.Globalization.NumberStyles.HexNumber);
	
	// Converts to 6 character hex string so the next operation will always work
	var convertedInput = numberConversion.ToString("X6");
	
	var aVal = int.Parse(convertedInput.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
	var rVal = int.Parse(convertedInput.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
	var gVal = int.Parse(convertedInput.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
	var bVal = int.Parse(convertedInput.Substring(6,2), System.Globalization.NumberStyles.HexNumber);
	
	// Prints result
	Console.WriteLine($"A: {aVal} R: {rVal} G: {gVal} B: {bVal}");
