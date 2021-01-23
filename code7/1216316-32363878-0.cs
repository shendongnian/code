	public void AddDataTableRows(DataTable datatable, Func<student, bool> predicate)
	{
		foreach (student s in studentList)
		{
			if (predicate(s))
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
