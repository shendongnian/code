    class Program
    {
        static void Main(string[] args)
        {
            // Data source
            List<Student> students = new List<Student>();
            students.Add(new Student { Id = 1, Name = "A" });
            students.Add(new Student { Id = 2, Name = "B" });
            students.Add(new Student { Id = 3, Name = "A" });
            students.Add(new Student { Id = 4, Name = "D" });
            // Apply Sorting
            var sorttedStudents = students.AsQueryable().ApplySort("id");
            var sorttedStudents1 = students.AsQueryable().ApplySort("-id");
            var sorttedStudents2 = students.AsQueryable().ApplySort("-name,id");
            Console.ReadKey();
        }
    }
    public static class IQueryableApplyFilterExtension
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string key)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "Data source is empty.");
            }
            if (key == null)
            {
                return source;
            }
            var lstSort = key.Split(',');
            string sortExpression = string.Empty;
            foreach (var sortOption in lstSort)
            {
                if (sortOption.StartsWith("-"))
                {
                    sortExpression = sortExpression + sortOption.Remove(0, 1) + " descending,";
                }
                else
                {
                    sortExpression = sortExpression + sortOption + ",";
                }
            }
            if (!string.IsNullOrWhiteSpace(sortExpression))
            {
                // Note: Install-Package: system.linq.dynamic NuGet package is required here to operate OrderBy on string
                // Then use using System.Linq.Dynamic; namespace
                source = source.OrderBy(sortExpression.Remove(sortExpression.Count() - 1));
            }
            return source;
        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
