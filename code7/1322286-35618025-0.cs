	var gradeFromMarkMethods = new Dictionary<int, Func<int, string>>()
	{
		{ 0, vetMethod.VETGrade },
		{ 1, newVETMethod.VETGrade },
		{ 2, gradeMethod.CollegeGrade },
	};
	Func<int, string> gradeFromMark;
	if (gradeFromMarkMethods.TryGetValue(ComboBoxGradeMethod.SelectedIndex, out gradeFromMark))
	{
		foreach (Student item in mark)
		{
			item.Grade = gradeFromMark(item.Mark);
		}
	}
	else
	{
		MessageBox.Show("Please select a grading scheme.");
	}
