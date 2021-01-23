    foreach (int thisColor in allColors)
    {
        List<Subject> subjectsForThisColor = subjects.Where(x => x.Color == thisColor).ToList();
        foreach (Subject s in subjectsForThisColor)
        {
            test += s.SubjectName + " -" + s.Color + "\n";
            switch (s.Color)
            {
                case 1:
                    updateOneRow("Monday", "first", s.SubjectName, null);
                    break;
                case 2:
                    updateOneRow("Monday", "second", s.SubjectName, null);
                    break;
                case 6:
                    updateOneRow("Monday", "sixth", s.SubjectName, null);
                    break;
            }
        }
    }
