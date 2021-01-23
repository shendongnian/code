    [Test]
            public void Method()
            {
                Person p = new Person {Id = 1};
                var mockSet = new Mock<IPersons>();
                var mockContext = new Mock<DatabaseContext>();
                mockContext.Setup(m => m.Persons).Returns(mockSet.Object);
                var repository = new Repository(mockContext.Object);
                repository.SaveOrUpdatePerson(p, 2);
                mockSet.Verify(x => x.SaveOrUpdate(p, 2), Times.Once);
            }
    
    
            public class Repository
            {
                private DatabaseContext databaseContext;
    
                public Repository(DatabaseContext databaseContext)
                {
                    this.databaseContext = databaseContext;
                }
    
                public void SaveOrUpdatePerson(Person p, int id)
                {
                    databaseContext.Persons.SaveOrUpdate(p, id);
                }
            }
    
            public class DatabaseContext
            {
                public virtual IPersons Persons { get; set; }
            }
    
            public interface IPersons
            {
                // add whatever else needed here
                void SaveOrUpdate(ModelJsonSerializationTest.Person p, int id);
            }
    
            public class Persons : IPersons
            {
                List<Person> persons = new List<Person>();
                public void SaveOrUpdate(Person p, int  id)
                {
                    if (persons.Any(x => x.Id == id)) // whatever you are using id for
                    { //Do update here
                    }
                    else
                    {
                        persons.Add(p);
                    }
                }
            }
    
            public class Person
            {
                public int Id { get; set; }
            }
