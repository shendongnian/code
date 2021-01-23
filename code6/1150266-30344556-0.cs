    public sealed class Company
    {
        private readonly Dictionary<string, Lazy<Employee>> _cache = new Dictionary<string, Lazy<Employee>>();
        public Company()
        {
            _cache["CEO"]            = new Lazy<Employee>(CeoFactory.NewCeo);
            _cache["Janitor"]        = new Lazy<Employee>(JanitorFactory.NewJanitor);
            _cache["IosProgrammer"]  = new Lazy<Employee>(ProgrammerFactory.NewIosProgrammer);
            _cache["JavaProgrammer"] = new Lazy<Employee>(ProgrammerFactory.NewJavaProgrammer);
        }
        public IEnumerable<Employee> GetEmployeesPresentToday(bool cond1, bool cond2, bool cond3, bool cond4)
        {
            if (cond1)
                yield return _cache["CEO"].Value;
            if (cond2)
                yield return _cache["JavaProgrammer"].Value;
            if (cond3)
                yield return _cache["IosProgrammer"].Value;
            if (cond4)
                yield return _cache["Janitor"].Value;
        }
