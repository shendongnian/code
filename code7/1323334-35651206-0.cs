    public class EmployeeSpecificUsage {
        private readonly Employee wrapped;
        public EmployeeSpecificUsage(Employee e) {
            wrapped = e;
        }
        public string firstName => wrapped.firstName;
        public string field1 => wrapped.field1;
        // Two fields above use C# 6 syntax. If it is not available,
        // use syntax below:
        public int age {
            get {
                return wrapped.age;
            }
        }
    }
