    string[] Ques = new string[5];
    Ques[0] = "How do you say Good morning  in Portuguese";
    Ques[1] = "how do you say how are you;";
    Ques[2] = "how do you say I am fine thank you";
    Ques[3] = "How do you say is everything ok";
    Ques[4] = "how do you say yes";
    foreach (string Q in Ques)
    {
        Console.WriteLine(Q);
        string Answer = Console.ReadLine();
        int value;
        while (int.TryParse(Answer, out value))
        {
            Console.WriteLine("please enter a word");
            Answer = Console.ReadLine();
        }
    }
