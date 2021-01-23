    for(int i = 0; i < Ques.Length; i++)
    {
        Console.WriteLine(Q);
        string Answer = Console.ReadLine();
        int value;
        if (int.TryParse(Answer, out value))
        {
             Console.WriteLine("please enter a word");
             i--; // go back, and will go forward in for statement
        } 
    }
