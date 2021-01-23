    // Store the average as a double array, otherwise you can't have averages with decimal values.
    double[] average = new double[studentGrades.GetLength(0)];
    for (int i = 0; i < studentGrades.GetLength(0); i++)
    {
        // Start from j = 1, as j = 0 would get a name instead of a grade.
        for (int j = 1; j < studentGrades.GetLength(1); j++)
        {
            // Here use average[i] instead of average[j], because you want
            // the average grade for each student.
            average[i] += int.Parse(studentGrades[i, j]);
        }
        
        // Finish calculating the average.
        // GetLength(0) - 1 because the first item is a name, not a grade.
        average[i] /= studentGrades.GetLength(1) - 1;
    }
    for (int i = 0; i <= average.GetLength(0) - 1; i++)
    {
        // Show at most 2 decimal digits.
        Console.Write("{0, -15:#.##}", average[i]);
    }
