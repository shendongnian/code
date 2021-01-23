    public class Tests
    {
        [Test]
        public void MergeSpike()
        {
            // the current list
            var currentList = new List<Employee>();
            currentList.Add(new Employee { Id = 154, Name = "George", Salary = 10000 });
            currentList.Add(new Employee { Id = 233, Name = "Alice", Salary = 10000 });
            // new list
            var newList = new List<Employee>();
            newList.Add(new Employee { Id = 154, Name = "George", Salary = 25000 });
            newList.Add(new Employee { Id = 234, Name = "Bob", Salary = 30000 });
            currentList.Merge(newList, (o, n) =>
            {
                if(o.Id != n.Id) throw new ArgumentOutOfRangeException("Attempt to merge on mismatched IDs");
                o.Name = n.Name;
                o.Salary = n.Salary;
            });
            Assert.That(currentList.Count(), Is.EqualTo(2));
            Assert.That(currentList.First(c => c.Id == 154).Salary, Is.EqualTo(25000));
            Assert.That(currentList.Any(c => c.Id == 233), Is.False);
            Assert.That(currentList.First(c => c.Id == 234).Salary, Is.EqualTo(30000));
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
    public static class EmployeeListExtensions
    {
        public static void Merge(this List<Employee> currentList, IEnumerable<Employee> newList, Action<Employee, Employee> merge)
        {
            // Updates
            currentList.Where(e => newList.Any(n => n.Id == e.Id))
                .ToList().ForEach(e => merge(e, newList.First(n1 => n1.Id == e.Id)));
            // Deletes
            var remove = currentList.Where(cl => newList.All(nl => cl.Id != nl.Id)).ToList();
            currentList.RemoveAll(e => remove.Any(r => r.Id == e.Id));
            // Inserts
            currentList.AddRange(newList.Where(nl => currentList.Any(c => c.Id != nl.Id)));
        }
    }
