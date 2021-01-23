     public class ParallelLoad
    {
        public List<object> Initialize()
        {
            var tasks = new[] { 
                Task.Run<object>(()=>new Customer()),
                Task.Run<object>(()=>new Employee()),
                Task.Run<object>(()=>new Address())
              };
            return tasks.Select(x => x.Result).ToList();
            //return new List<object>
            //{
            //    new Customer(),
            //    new Employee(),
            //    new Address()
            //};
        }
    }
    class Customer
    {
        public Customer()
        {
            for (var i = 0; i < 1000; i++)
            {
                Console.WriteLine("Customer: " + i);
            }
        }
    }
    class Employee
    {
        public Employee()
        {
            for (var i = 0; i < 1000; i++)
            {
                Console.WriteLine("Employee: " + i);
            }
        }
    }
    class Address
    {
        public Address()
        {
            for (var i = 0; i < 1000; i++)
            {
                Console.WriteLine("Address: " + i);
            }
        }
    }
    [TestFixture]
    public class ParallelLoadTest
    {
        [Test]
        public void Given_When_Then()
        {
            // Arrange
            var presenter = new ParallelLoad();
            // Act
            presenter.Initialize();
            // Assert
        }
    }
