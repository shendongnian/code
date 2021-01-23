    string choice = "YES";
    string answer = null;
    while (true)
    {
        answer = Console.ReadLine();
        if (answer.Trim().ToUpper().Equals(choice))
        {
            break;
        }
        else
        {
            Console.WriteLine("Error, say YES");
        }
    }
