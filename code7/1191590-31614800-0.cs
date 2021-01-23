    Console.WriteLine("Should X or O go first: ");
    string answer = Console.ReadLine();
    StringBuilder sb = new StringBuilder();
    if (answer.Equals("X")
    {
        for (int i = 0; i < 4; i++)
            sb.Append("xo");
    }
    else
    {
        for (int i = 0; i < 4; i++)
            sb.Append("ox");
    }
    Console.WriteLine(sb.ToString());
