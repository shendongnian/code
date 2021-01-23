    using System.Linq;
    using System.Data.Entity;
    namespace Sample
    {
----------
        class Program
        {
            static void Main(string[] args)
            {
                using (var context = new EmployeeDBContext())
                {
                    var result = context.Set<Employee>().Include(x => x.Department).ToArray();
                }
            }
        }
