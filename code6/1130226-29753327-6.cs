    IEnumberable<int> InputGrades()
    {
        var count = GetNum();
        var grades = new List<int>();
        for (var i = 0; i < count; i++)
           grades.Add(InputGrade());
        return grades;
    }
    void OutputScores(IEnumerable<int> grades)
    {
        var scores  = grades.Cast<doulbe>().ToArray();
        var lowest  = scores.Min();
        var highest = scores.Max();
        var average = scores.Average();
        Console.WriteLine("The average grade of the scores is" + average);
        Console.WriteLine("The Lowest Score is" + lowest);
        Console.WriteLine("The Highest Score is" + highest);
    }
