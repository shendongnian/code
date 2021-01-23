    var source = new int[3, 3]
	{
		{ 33, 300, 500 },
		{ 56, 354, 516 },
		{ 65, 654, 489 }
	};
    // initialize destination array with expected length
	var dest = new int[source.GetLength(1)];
    // define row number
	var rowNumber = 1;
    // copy elemements to destination array
	for (int i = 0; i < source.GetLength(1); i++)
	{
		dest[i] = (int) source.GetValue(rowNumber, i);
	}
