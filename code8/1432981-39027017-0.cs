    public class VersionInfo
    {
        public int EmployeeId { get; set; }
        public decimal Version { get; set; }
    }
    
    class Program
    {
        public static string connString = "...";
    
        static void Main(string[] args)
        {
            var result = GetVersion(new List<int> {1, 2});
            Console.ReadLine();
        }
    
        public static List<VersionInfo> GetVersion(IList<int> employeeIds)
        {
            using (IDbConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                var entities = conn.Query<VersionInfo>(
                    @"SELECT EmployeeId, Version from EmployeeVersion WHERE EmployeeId IN @EmployeeIds",
                    new {EmployeeIds = employeeIds});
    
                return entities.ToList();
            }
        }
    }
