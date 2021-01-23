    private void ReadInputAndSumNumbers()
    {
        Console.Write("\nNumber you choose? ");
        int numberChosen;
        if(int.TryParse(Console.ReadLine(), out numberChosen)) {
            sum += numberChosen;
        }
        else {
            Console.WriteLine("Invalid choice.");
        }
    }
