    var random = new Random();
	var input = Enumerable.Range(1, 100).Select(_ => random.Next(200) - 100).ToList();
    input.Sort(); // This causes most computation. Time Complexity is O(n*log(n));
	var expectedSum = 0;
	var i = 0;
	var j = input.Count - 1;
	while (i < j) // This has liner time complexity O(n);
	{
		var result = input[i] + input[j];
		if(result==expectedSum) {
			Console.WriteLine($"{input[i]}, {input[j]}");
			i++;
			j--;
		}
		else if(result < expectedSum) {
			i++;
		}
		else if(result > expectedSum) {
			j--;
		}
	}
