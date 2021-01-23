    using System;
    using System.Collections.Generic;
    using System.Reactive.Subjects;
    
    
    namespace SchoolManagementSystem
    {
        public class Student
        {
            public Student(string name)
            {
                Name = name;
            }
    
            public string Name { get; set; }
        }
    
    	public class School : IObservable<Student>
    	{
    		private List<Student> _students;
    		private Subject<Student> _subject = null;
    
    		public static readonly int MaximumNumberOfSeats = 100;
    
    		public string Name { get; set; }
    
    		public School(string name)
    		{
    			Name = name;
    			_students = new List<Student>();
    			_subject = new Subject<Student>();
    		}
    
    		public void AdmitStudent(Student student)
    		{
    			if (student == null)
    			{
    				var ex = new ArgumentNullException("student");
    				_subject.OnError(ex);
    				throw ex;
    			}
    
    			try
    			{
    				if (_students.Count == MaximumNumberOfSeats)
    				{
    					_subject.OnCompleted();
    
    					return;
    				}
    
    				if (!_students.Contains(student))
    				{    
    					_students.Add(student);
    
    					_subject.OnNext(student);
    				}
    			}
    			catch(Exception ex)
    			{
    				_subject.OnError(ex);
    			}
    		}
    
    		public IDisposable Subscribe(IObserver<Student> observer)
    		{
    			return _subject.Subscribe(observer);
    		}
    	}
    }
