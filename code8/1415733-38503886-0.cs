    static void ObserveStudentsJoiningWithin(TimeSpan timeSpan)
    {
    	var school = new School("School 1");
    
    	var admissionObservable =
    		Observable.FromEventPattern<StudentAdmittedEventArgs>(school, "StudentAdmitted");
    
    	var observable = admissionObservable.TimeInterval()
    		.Scan<TimeInterval<EventPattern<StudentAdmittedEventArgs>>, StudentPair>(null, (previousPair, current) =>
    		{
    			Debug.Print(string.Format($"Student joined after {current.Interval.TotalSeconds} seconds, timeSpan = {timeSpan.TotalSeconds} seconds"));
    
    			var pair = new StudentPair();
    
    			if (previousPair == null)
    			{
    				pair.FirstStudent = null;
    				pair.SecondStudent = current.Value.EventArgs.Student;
    				pair.IntervalBetweenJoining = current.Interval;
    				pair.School = current.Value.EventArgs.School;
    
    				return pair;
    			}
    
    			if (current.Interval <= timeSpan)
    			{
    				pair.FirstStudent = previousPair.SecondStudent;
    				pair.SecondStudent = current.Value.EventArgs.Student;
    				pair.IntervalBetweenJoining = current.Interval;
    				pair.School = current.Value.EventArgs.School;
    
    				return pair;
    			}
    			else
    			{
    				return default(StudentPair);
    			}
    		})
    		.Where(p => (p != default(StudentPair)) && (p.FirstStudent != null));
    
    	var subscription = observable.Subscribe(StudentPairValueHandler);
    
    	school.FillWithStudents(4, TimeSpan.FromSeconds(1));
    	school.FillWithStudents(2, TimeSpan.FromSeconds(10));
    	school.FillWithStudents(3, TimeSpan.FromSeconds(2));
    	school.FillWithStudents(2, TimeSpan.FromSeconds(5));
    	school.FillWithStudents(5, TimeSpan.FromSeconds(0.6));
    
    	Console.WriteLine("Press any key to exit the program");
    	Console.ReadKey();
    	subscription.Dispose();
    }
    
    static void StudentPairValueHandler(StudentPair pair)
    {
    	if (pair != null && pair.FirstStudent != null)
    	{
    		Console.WriteLine($"{pair.SecondStudent.Name} joined {pair.School.Name} {Math.Round(pair.IntervalBetweenJoining.TotalSeconds, 2)} seconds after {pair.FirstStudent.Name}.");
    	}
    }
    
    ...
    
    public class StudentPair
    {
    	public Student FirstStudent;
    	public Student SecondStudent;
    	public School School;
    	public TimeSpan IntervalBetweenJoining;
    }
    public static class Extensions
    {
    	public static void FillWithStudents(this School school, int howMany)
    	{
    		FillWithStudents(school, howMany, TimeSpan.Zero);
    	}
    
    	public static void FillWithStudents(this School school, int howMany, TimeSpan gapBetweenEachAdmission)
    	{
    		if (school == null)
    			throw new ArgumentNullException("school");
    
    		if (howMany < 0)
    			throw new ArgumentOutOfRangeException("howMany");
    
    		if (howMany == 1)
    		{
    			school.AdmitStudent(Student.CreateRandom());
    			return;
    		}
    
    		for (int i = 0; i < howMany; i++)
    		{
    			Thread.Sleep((int)gapBetweenEachAdmission.TotalMilliseconds);
    
    			school.AdmitStudent(Student.CreateRandom());
    		}
    	}
    
    	public async static void FillWithStudentsAsync(this School school, int howMany, TimeSpan gapBetweenEachAdmission)
    	{
    		if (school == null)
    			throw new ArgumentNullException("school");
    
    		if (howMany < 0)
    			throw new ArgumentOutOfRangeException("howMany");
    
    		if (howMany == 1)
    		{
    			school.AdmitStudent(Student.CreateRandom());
    			return;
    		}
    
    		for (int i = 0; i < howMany; i++)
    		{
    			await Task.Delay(gapBetweenEachAdmission);
    
    			school.AdmitStudent(Student.CreateRandom());
    		}
    	}
    }
