    var lines = File.ReadLines(@"U:\StudentExamMarks.txt")
        .Where(l => !String.IsNullOrWhiteSpace(l));
    List<StudentExam> studentsMarks = new List<StudentExam>();
    foreach (string line in lines)
    {
        string[] tokens = line.Split('\t');
        string markToken = tokens.Last().Trim();
        int mark;
        if (tokens.Length > 1 && int.TryParse(markToken, out mark))
        { 
            StudentExam exam = new StudentExam{
                Mark = mark,
                StudentName = String.Join(" ", tokens.Take(tokens.Length - 1)).Trim()
            };
            studentsMarks.Add(exam);
        }
    }
