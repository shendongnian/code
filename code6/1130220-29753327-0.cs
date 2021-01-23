    public int InputGrade()
    {
        Console.Clear();
        Console.WriteLine("Please enter a grade [1-10]");
        var grade = -1;
        if (!Int32.TryParse(Console.ReadLine()))
            return InputGrade();
        if (grade < 1 || grade > 10)
            return InputGrade();
        
        return grade;
    }
