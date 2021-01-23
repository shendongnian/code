    public class MyProgram
    {
    
        public bool hello(string name, int age)
        {
            string lastName = GetLastName();
            
            return string.Format("hello {0}", lastName);
        }
    
        public virtual string GetLastName() 
        {
            return "xxx"; 
        }
    }
    public class MyProgramTests
    {
    
        [TestMethod]
        public void MyTest()
        {
    
            string stringToReturn = "qqq";
            Mock<MyProgram> name = new Mock<MyProgram>();
            name.CallBase = true;
            name.Setup(x => x.GetLastName()).Returns(stringToReturn );
            var results = name.Object.hello(It.IsAny<string>(), It.IsAny<int>());
            string expected = string.Format("hello {0}", results);
    
            Assert.AreEqual(expected, results);
        }
    }
