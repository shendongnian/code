    public void AddDataTableRows(DataTable datatable, Predicate<Student> condition)
    {
        foreach (student s in studentList.Where(condition))
        {
            datatable.Rows.Add(s.name,
                               s.totalDays,
                               s.improveOverall,
                               s.totalClassDays,
                               s.instructor,
                               s.grade);
        }
    }
