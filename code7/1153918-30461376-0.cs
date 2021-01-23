    namespace CollegeService
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            List<Student> StudentList();
    
            [OperationContract]
            void NewStudent(Student s);
        }
    
        // Use a data contract as illustrated in the sample below to add composite types to service operations.
        // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "CollegeService.ContractType".
        [DataContract]
        public class Student
        {
    
            [DataMember]
            public string OIB
            {
                get;
                set;
            }
    
            [DataMember]
            public string Name
            {
                get;
                set;
            }
    
            [DataMember]
            public string SchoolYear
            {
                get;
                set;
            }
        }
    }
    
    namespace CollegeService
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
        public class Service : IService
        {
            private List<Student> _students;
    
            public Service()
            {
                this._students = new List<Student>();
            }
    
            public void NewStudent(Student s)
            {
                this._students.Add(s);
            }
    
            public List<Student> StudentList()
            {
                return this._students;
            }
        }
    }
