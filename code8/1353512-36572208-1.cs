    public abstract class Contract
    {
        public decimal Salery { get; set; }
    }
    public class EmployeePermanent : Contract {
    }
    
    public class Employee : Contract
    {
        public int Id { get; set; }
    
        public int Sl { get; set; }
    
        public void Test()
        {
            new List<Employee>().AsQueryable().GetTotalSalary(x => x.Id == 12 && x.Sl == 100);
        }
    }
    
    public static class QueryExtensions
    {
        public static decimal GetTotalSalary<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> expression) where T : Contract
        {
            return queryable.Where(expression).Sum(arg => arg.Salery);
        }
    }
