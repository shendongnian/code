    var random = new Random();
	var input = Enumerable.Range(1, 100).Select(_ => random.Next(200) - 100).ToArray();
    Array.Sort(input); // This causes most computation. Time Complexity is O(n*log(n));
	var expectedSum = 0;
	var i = 0;
	var j = input.Length - 1;
	while (i < j) // This has liner time complexity O(n);
	{
        var result = input[i] + input[j];
        if(expectedSum == result)
        {
			var anchori = i;
			while (input[i] == input[anchori])
			{
				i++;
			}
			var anchorj = j;
			while (input[j] == input[anchorj])
			{
				j--;
			}
			for (int k = 0; k < (i - anchori) * (anchorj - j); k++)
			{
				Console.WriteLine($"{input[anchori]}, {input[anchorj]}");
			}
		}
		else if(result < expectedSum) {
			i++;
		}
		else if(result > expectedSum) {
			j--;
		}
	}
