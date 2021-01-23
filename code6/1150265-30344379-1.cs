    public class Company {
      private Dictionary<string, Employee> _CacheEmployees { get;} = new Dictionary<string, Employee>();
      public Employee GetEmployee(string key, Func<Employee> factory) {
        // Existence of this method is not really annoying as it only has to be written once.
        private Dictionary<string, Employee> cache = this._CacheEmployees;
        Employee r = null;
        if (cache.ContainsKey(key)) {
          r = cache[key];
        }
        if (r == null) {
          r = factory();
          cache[key] = r;
        }
        return r;
      }
      public IEnumerable<Employee> GetEmployeesPresentToday() {
        // still somewhat messy, but perhaps better than the question code.
        List<Employee> r = new List<Employee>();
        if (ExternalCondition1) {   // value of the condition may differ on successive calls to this method
          r.Add(this.GetEmployee("CEO", CEOFactory.NewCEO));
        };
        if (ExternalCondition2) {   // all conditions are external to the Company class, and it does not get notified of changes.
          r.Add(this.GetEmployee("Java Programmer", ProgrammerFactory.NewJavaProgrammer));
        }
        if (ExternalCondition3) {
          r.Add(this.GetEmployee("IOS Programmer", ProgrammerFactory.NewIOSProgrammer));
        }
        if (ExternalCondition4) {
          r.Add(this.GetEmployee("Janitor", JanitorFactory.NewJanitor));
        }
        // etc.
        return r;
      }
    }
