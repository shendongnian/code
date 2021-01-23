       sum = 0;
       for (int p = 1; p <= numberOfTests; p++)
       {
            Console.Write("Test {0} grade: ", p);
            float.TryParse(Console.ReadLine(), out grade);
            sum = sum + grade;
            average = sum / numberOfTests;
       }
