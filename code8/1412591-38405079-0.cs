    HandleQuestion(1, 6);
    HandleQuestion(2, 3);
    HandleQuestion(8, 9);
    HandleQuestion(5, 6);
    HandleQuestion(4, 6);
    void HandleQuestion(int operand1, int operand2)
    {
        Console.WriteLine("What is {0} x {1}", operand1, operand2);
        string userAnswer = Console.ReadLine();
        if (userAnswer == (operand1 * operand2).ToString())
            Console.WriteLine("Correct");
        else
            Console.WriteLine("Incorrect");
