	public string FormatDetailsForDisplay()
	{
		return String.Format("Course ID: {0} - Name: {1}\r\n{2}", 
							 this.CourseId, 
							 this.Name,
							 String.Join("", this.Students.Select(s => s)));
	}
