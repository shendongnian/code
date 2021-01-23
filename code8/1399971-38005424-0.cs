    using System;
    using AlternativesCommon;
    using NUnit.Framework;
    using Moq;
    
    /// <summary>
    /// This demostrates how to use all approaches.
    /// </summary>
    namespace Usage
    {
        public class Program
        {
            public static void Main()
            {
                var myData = new Original.MyData();
                myData.GetData();
    
                var myData1 = new Alternative1.MyData(new StandardConsole());
                myData1.GetData();
    
                var myData2 = new Alternative2.MyDataController(new StandardConsole(), new Alternative2.MyData());
                myData2.GetData();
            }
        }
    
    }
    
    /// <summary>
    /// This demonstrates how to test each approach.
    /// </summary>
    namespace Tests
    { 
        public class Alternative1Tests
        {
            /// <summary>
            /// The original apporach is too tightly coupled to be unit tested.
            /// </summary>
            [Test]
            public void Original_MyDataCannotBeAutomatedTested()
            {
            }
    
            /// <summary>
            /// The first alternative abstracts the console out.
            /// This is better, but still requires a lot of mocking and syntax.
            /// </summary>
            [Test]
            public void Alternative1_MyDataShouldWork()
            {
                // Arrange
                var mockConsole = new Mock<IConsole>();
    
                mockConsole.Setup(c => c.WriteLine("Please Enter your Name(only Alphabet)"));
                mockConsole.Setup(c => c.ReadLine()).Returns("John");
                mockConsole.Setup(c => c.WriteLine("John"));
    
                var myData = new Alternative1.MyData(mockConsole.Object);
    
                // Act
                myData.GetData();
    
                // Assert
                mockConsole.VerifyAll();
            }
    
            /// <summary>
            /// The second alternative abstracts the data model out.
            /// This allows us to unit test just our domain logic.
            /// We can test the controller in a larger boundary or integration test if we want (not shown).
            /// </summary>
            [Test]
            public void Alternative2_MyDataShouldWork()
            {
                // Arrange
                var name = "John";
                var myData = new Alternative2.MyData();
                var initialValue = myData.Name;
    
                // Act
                myData.Name = name;
    
                // Assert
                Assert.That(initialValue, Is.Null);
                Assert.That(myData.Name, Is.EqualTo(name));
            }
    
            /// <summary>
            /// This shows how one would unit test the controller.
            /// Lots of mocking (ew!).
            /// </summary>
            [Test]
            public void Alternative2_MyDataControllerShouldWork()
            {
                // Arrange
                var mockConsole = new Mock<IConsole>();
    
                mockConsole.Setup(c => c.WriteLine("Please Enter your Name(only Alphabet)"));
                mockConsole.Setup(c => c.ReadLine()).Returns("John");
                mockConsole.Setup(c => c.WriteLine("John"));
    
                string name = null;
                var mockData = new Mock<Alternative2.IMyData>();
                mockData.SetupGet(d => d.Name).Returns(() => name);
                mockData.SetupSet(d => d.Name = It.IsAny<string>()).Callback((string value) => name = value);
    
                var controller = new Alternative2.MyDataController(mockConsole.Object, mockData.Object);
    
                // Act
                controller.GetData();
    
                // Assert
                mockConsole.VerifyAll();
                mockData.VerifyAll();
            }
        }
    }
    
    namespace Original
    {
        public class MyData
        {
            private string _name;
    
            public void GetData()
            {
                Console.WriteLine("Please Enter your Name(only Alphabet)");
                _name = Console.ReadLine();
                Console.WriteLine(_name);
            }
        }
    }
    
    namespace Alternative1
    {
        public class MyData
        {
            private string _name;
            private IConsole _console;
    
            public MyData(IConsole console)
            {
                this._console = console;
            }
    
            public void GetData()
            {
                this._console.WriteLine("Please Enter your Name(only Alphabet)");
                this._name = this._console.ReadLine();
                this._console.WriteLine(this._name);
            }
        }
    }
    
    namespace Alternative2
    {
        public interface IMyData
        {
            string Name
            {
                set;
                get;
            }
        }
        
        public class MyData : IMyData
        {
            private string _name;
    
            public string Name
            {
                set
                {
                    // Do any validation here.  For example, uncomment out the following (don't forget to test!):
    
                    //if (string.IsNullOrEmpty(value))
                    //{
                    //    throw new Exception(@"Name cannot be empty or null.");
                    //}
    
                    //if (value.Length > 100)
                    //{
                    //    throw new Exception(@"Name cannot be longer than 100 characters.");
                    //}
    
                    this._name = value;
                }
                get
                {
                    return this._name;
                }
            }
        }
    
        public class MyDataController
        {
            private IConsole _console;
            private IMyData _data;
    
            public MyDataController(IConsole console, IMyData data)
            {
                this._console = console;
                this._data = data;
            }
    
            public void GetData()
            {
                this._console.WriteLine("Please Enter your Name(only Alphabet)");
                this._data.Name = this._console.ReadLine();
                this._console.WriteLine(this._data.Name);
            }
        }
    }
    
    /// <summary>
    /// Defines the console abstraction used by both alternatives.
    /// </summary>
    namespace AlternativesCommon
    {
        public interface IConsole
        {
            string ReadLine();
            void WriteLine(string line);
        }
    
        public class StandardConsole : IConsole
        {
            public string ReadLine()
            {
                return Console.ReadLine();
            }
    
            public void WriteLine(string line)
            {
                Console.WriteLine(line);
            }
        }
    }
