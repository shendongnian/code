    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    
    namespace Tests
    {
        public interface IEntity
        {
            DateTime Created { get; set; }
        }
    
        public class MyClass : IEntity
        {
            public DateTime Created { get; set; }
        }
    
        [TestClass]
        public class UnitTest1
        {
            private readonly DateTime _exampleDate;
    
            public UnitTest1()
            {
                _exampleDate = DateTime.Now;
            }
    
            public virtual void Insert(IEntity entity)
            {
                entity.Created = _exampleDate;
                // other code ommitted
            }
    
            [TestMethod]
            public void TestMethod1()
            {
                MyClass myTest = new MyClass();
                Insert(myTest);
    
                Assert.AreEqual(_exampleDate, myTest.Created);
            }
        }
    }
