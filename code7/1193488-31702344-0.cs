    void Main()
    {
    	var json = JsonConvert.DeserializeObject<List<Student>>(yourJson);
    	
    	json.ForEach(x => {
    		var student = GetEntity<Student>(s => s.Id == x.Id);
    		
    		if(student != null)
    		{
    		    //replace disconnected entity with connected reference
    			x = student;
    			
    			student.Courses.ForEach(sc =>
    			{
    				var course = GetEntity<Course>(c => c.Id == sc.Id);
    				sc = course;
    			});
    		}
    	});
    }
    
    public T GetEntity<T>(Func<T, bool> predicate) where T : class
    {
        return yourContext.Set<T>().FirstOrDefault(predicate);
    }
