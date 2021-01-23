    foreach (string Q in Ques)
    {
        bool numberEntered = false;
        do
        {
            Console.WriteLine(Q);
            string Answer = Console.ReadLine();
            int value;
            numberEntered = int.TryParse(Answer, out value);
            if (numberEntered)
            {
                Console.WriteLine("please enter a word");
            }
        }
        while (numberEntered);
    }
