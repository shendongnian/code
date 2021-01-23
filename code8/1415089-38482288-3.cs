    public void AdmitStudent(Student student)
    {
    	try
    	{
    		if (_students.Count == MaximumNumberOfSeats)
    		{
    			...
    		}
    
    		if (!_students.Contains(student))
    		{
    			// Add this line to indicate which school
    			// the student is being admitted to
    			student.School = this;
    
    			_students.Add(student);
    
    			_subject.OnNext(student);
    		}
    	}
    	catch(Exception ex)
    	{
    		_subject.OnError(ex);
    	}
    }
