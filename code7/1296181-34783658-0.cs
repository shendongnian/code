    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace SampleManager
    {
        public class Manager : IManager
        {
            private IHiveTiesContext _ctx;
            public Manager(IHiveTiesContext context)
            {
                _ctx = context;
            }
    
            public Person CreatePerson(string fn, string ln, DateTime dob, char gender, Guid RId)
            {
                var person = _ctx.Save(fn, ln);
                return person;
            }
        }
    
    
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public char Gender { get; set; }
            public DateTime DOB { get; set; }
            public Guid RowId { get; set; }
        }
    
        public interface IManager
        {
            Person CreatePerson(string fn, string ln, DateTime dob, char gender, Guid RId);
        }
    
        public interface IHiveTiesContext
        {
            Person Save(string fn, string ln);
        }
    }
    /// <summary>
        ///A test for CreatePerson
        ///</summary>
        [TestMethod()]
        public void CreatePersonTest1()
        {
            var mock = new Mock<IHiveTiesContext>();
            //fill up your expected object
            mock.Setup(m => m.Save(It.IsAny<string>(), It.IsAny<string>())).Returns(new Person { FirstName = "William" });
            Manager t = new Manager(mock.Object);
            var results = t.CreatePerson(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<Char>(), It.IsAny<Guid>());
            Assert.AreEqual("William", results.FirstName);
        }
