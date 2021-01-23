    Console.WriteLine("Welcome to the Ultimate quiz!");
    Console.WriteLine();
    int count = 0;
    while(questions.Count > 0) {
        Console.WriteLine(question.First().Text + " (question left: " + questions.Count + ")");
        string answer = Console.ReadLine();
        if (answer == questions.First().Answer)
        {
            Console.WriteLine();
            Console.WriteLine("Well Done, you may move on to the next question");
            questions.RemoveAt(0);
        }
        else
        {
            Console.WriteLine("Sorry you got the answer wrong, you have to start again");
            count++;
        }
    }
     Console.WriteLine();
     Console.WriteLine("you took " + count + " time(s) to complete the quiz");
