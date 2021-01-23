    public class Employee
    {
        private List<Skills> _skills;       // skills stored as a private List 
                                            // to allow modification inside Employee class
        public Employee(Job job, string name, params Skills[] skills)
        {
            _skills = new List<Skills>(skills);
            ...
        }
        public IReadOnlyList<Skills> Skills // publicly visible as a read-only list
        {
            get { return _skills.AsReadOnly(); }
        }
        
        ...
    }
