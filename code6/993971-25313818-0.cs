	//System.IO.StreamReader file = new System.IO.StreamReader(@"c:\AnswerFile.txt");
	//System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(@"C:\outputFile.txt");
	if (args.Length < 2)
    {
        throw new Exception("File(s) not provided.");
    }
    System.IO.StreamReader file = new System.IO.StreamReader(args[0]);
    System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(args[1]);
