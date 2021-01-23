    object[,] input = GetSelectedRange();
	string[,] output = new string[input.GetLength(0), input.GetLength(1)];
	for (int i = 0; i < input.GetLength(0); ++i)
		for (int j = 0; j < input.GetLength(1); ++j)
			output[i, j] = input[i, j].ToString();
