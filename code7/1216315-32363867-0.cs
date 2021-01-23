    public void AddDataTableRows(DataTable datatable, Func<Student,bool> cond)
    {
        foreach (student s in studentList)
        {
            if (cond(s))
            {
                datatable.Rows.Add(s.name,
                    s.totalDays,
                    s.improveOverall,
                    s.totalClassDays,
                    s.instructor,
                    s.grade);
            }
        }
    }
