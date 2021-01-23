	Console.WriteLine("Enter Student ID");
	String ID = Console.ReadLine();			
	string answer = "TFTTFTFFTF";
	string studentAnswers = "TTFFTFTTFT";
	int count = 0;
	for (int i = 0; i < answer.Length; i++)
	{
		if (answer[i] == studentAnswers[i])
		{
			count++;
		}
	}
	if (ID == "5")
	{
		Console.WriteLine("This student mark is");
		Console.WriteLine(count);
	}
	else
	{
		Console.WriteLine("error no student with this ID");
	}
	Console.ReadLine();
