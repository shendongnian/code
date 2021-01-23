    public class Program
    {
        public static void Main(string[] args)
        {
            Program p = new Program();
        }
        public Program()
        {
            var bossEmpCollection = new List<BossEmp>()
            {
                new BossEmp() { SNo = 2, JobID = 1, BossID = 6, EmpID = 2, StartDt = DateTime.Now },
                new BossEmp() { SNo = 1, JobID = 1, BossID = 6, EmpID =  1, StartDt = DateTime.Now }
            };
            var employeeCollection = new List<Employee>()
            {
                new Employee() { EmpID = 1, EmpName = "Sakthivel", Gender = 'M', DOB = DateTime.Now, Dep = "Development" },
                new Employee() { EmpID = 2, EmpName = "Regina", Gender = 'F', DOB = DateTime.Now, Dep = "Development" }
            };
            var jobCollection = new List<Job>()
            {
                new Job() { JobID = 1, Title = "RSI", Description = "RSI" }
            };
            var workInfoCollection = from bEmp in bossEmpCollection
                                     join e in employeeCollection on bEmp.EmpID equals e.EmpID
                                     join j in jobCollection on bEmp.JobID equals j.JobID
                                     where e.Gender.Equals('F')
                                     select new WorkInfo() { EmpObject = e, JobInfo = j };
            foreach (var workInfo in workInfoCollection)
            {
                Console.WriteLine($"Emp Name: {workInfo.EmpObject.EmpName} Work Desc: {workInfo.JobInfo.Description}");
            }
            Console.ReadKey();
        }
    }
    public class BossEmp
    {
        public int SNo { get; set; }
        public int JobID { get; set; }
        public int BossID { get; set; }
        public int EmpID { get; set; }
        public DateTime StartDt { get; set; }
    }
    public class WorkInfo
    {
        public Employee EmpObject { get; set; }
        public Job JobInfo { get; set; }
    }
    public class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public char Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Dep { get; set; }
        
    }
    public class Job
    {
        public int JobID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
