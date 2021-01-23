        public class School
        {
            //private Subject<Student> _subject = null;
            private readonly ISubject<Student> _applicationStream = null;
            public static readonly int MaximumNumberOfSeats = 100;
            public string Name { get; set; }
            public School(string name)
                : this(name, new Subject<Student>())
            {
            }
            public School(string name, ISubject<Student> applicationStream )
            {
                Name = name;
                _applicationStream = applicationStream;
            }
            public void AdmitStudent(Student s)
            {
                _applicationStream.OnNext(s);
            }
            public IObservable<Student> ApplicationStream()
            {
                return _applicationStream;
            }
            public IObservable<Student> AcceptedStream()
            {
                return _applicationStream
                    .SelectMany(s => s != null ? Observable.Return(s) : Observable.Throw<Student>(new ArgumentNullException("student")))
                    .Distinct()
                    .Take(MaximumNumberOfSeats);
            }
        }
