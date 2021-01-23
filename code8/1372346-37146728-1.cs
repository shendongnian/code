    var input = "0xaa336539";
	
	var aVal = int.Parse(input.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
	var rVal = int.Parse(input.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
	var gVal = int.Parse(input.Substring(6,2), System.Globalization.NumberStyles.HexNumber);
	var bVal = int.Parse(input.Substring(8,2), System.Globalization.NumberStyles.HexNumber);
	
	Console.WriteLine($"A: {aVal} R: {rVal} G: {gVal} B:{bVal}");
	// A: 170 R: 51 G: 101 B:57
