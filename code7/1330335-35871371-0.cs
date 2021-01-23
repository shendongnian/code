    Console.Write("Please enter score for Exam 1 <Example: 100.0>: ");
    while(!Double.TryParse(Console.ReadLine(), out Exam_1))
    {
          Console.Write("Try again...");
    }
    while (Exam_1 < 0.0 || Exam_1 > 100.0)
    {
        Console.Write("Exam score cannot be less than 0. or greater than 100.0. Please re-enter the score for Exam 1 <Example: 95.0>:");
        Exam_1 = Convert.ToDouble(Console.ReadLine());
    }
