    public class TeacherObserver : IObserver
    {
        private int _currentSalery = 500;
        public string Mood { get; private set; }
        public ISubject subject;
        public ISubject Subject
        {
            get { return subject; } 
            set
            {
                // Relase old event
                if (subject != null) subject.OnNotify -= Update;
                subject = value;
                // Connect new event
                if (subject != null) subject.OnNotify += Update;
            } 
        }
        public TeacherObserver()
        {
            Mood = "Happy";
        }
        public void Update(object sender, EventArgs e)
        {
            ISalerySubject SalerySubject = Subject as ISalerySubject;
            if (SalerySubject != null)
            {
                var newSalery = SalerySubject.Salery;
                if (_currentSalery < newSalery)
                {
                    Mood = "Happy";
                }
                else
                {
                    Mood = "Sad";
                }
                _currentSalery = newSalery;
            }
        }
    }
