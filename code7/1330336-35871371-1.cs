    Console.Write("Please enter score for Exam 1 <Example: 100.0>: ");
    while(!Double.TryParse(Console.ReadLine(), out Exam_1))
    {
          Console.Write("Try again...");
    }
