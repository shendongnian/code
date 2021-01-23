        var studentMarks = new Dictionary<int, List<double>> (students.Count);
        foreach (var student in students)
        {
            int id = student.Id;
            List<double> marks;
            if (!studentMarks.TryGetValue (id, out marks))
            {
                studentMarks.Add (id, new List<double> ());
            }
            marks.Add (student.Marks);
        }
        double? bestAverage = null;
        int? idOfBest = null;
        foreach (var idAndMarks in studentMarks)
        {
            var average = 0.0;
            foreach (var mark in idAndMarks.Value)
            {
                average += mark;
            }
            average /= idAndMarks.Value.Count;
            if (average > bestAverage)
            {
                bestAverage = average;
                idOfBest = idAndMarks.Key;
            }
        }
