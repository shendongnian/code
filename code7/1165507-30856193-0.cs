    using FluentAssertions;
    using NSubstitute;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoNSubstitute;
    using Xunit;
    using Xunit.Abstractions;
    
    namespace Try.xUnit.Tests
    {
        public class TestingMethodCalls
        {
            private readonly ITestOutputHelper _output;
    
            public TestingMethodCalls(ITestOutputHelper output)
            {
                _output = output;
            }
    
    
            [Fact]
            public void should_set_property_to_sepecified_value()
            {
                var sut = Substitute.For<ISimple>();
                sut.Data.Returns("1,2");
    
                sut.Data.Should().Be("1,2");
            }
    
            [Fact (Skip="Don't quite understand how to use AutoFixture and NSubstitue together")]
            public void should_run_GetCommand_with_provided_property_value_old()
            {
                /* TODO:  
                 * How do I create a constructor with AutoFixture and/or NSubstitute such that:
                 *   1.  With completely random values.
                 *   2.  With one or more values specified.
                 *   3.  Constructor that has FileInfo as one of the objects.
                 * 
                 * After creating the constructor:
                 *   1.  Specify the value for what a property value should be - ex: sut.Data.Returns("1,2");
                 *   2.  Call "Execute" and verify the result for "Command"
                 * 
                 */
                // Arrange
                var fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
    //            var sut = fixture.Build<Simple>().Create();  // Not sure if I need Build or Freeze            
                var sut = fixture.Freeze<ISimple>();  // Note: I am using a Interface here, but would like to test the Concrete class
                sut.Data.Returns("1,2");
    
                // Act
                sut.Execute();
    
                // Assert (combining multiple asserts just till I understand how to use NSubstitue and AutoFixture properly
    //            sut.Received().Execute();
                sut.Data.Should().Be("1,2");
                sut.Command.Should().Be("1,2,abc");
                // Fails with : FluentAssertions.Execution.AssertionFailedExceptionExpected string to be "1,2,abc" with a length of 7, but "" has a length of 0.
            }
    
            /* Explanation:
             * Create a construtor without any arguments.
             *      Had to create a parameterless constructor just for testing purposes (would like to improve on this)
             * Specify a default value for the desired method or property.
             *      It is necessary that the property or method has to be virtual.
             *      To specify that the based mehod should be call use the "DoNotCallBase" before the "Returns" call
             */ 
            [Fact]
            public void should_run_GetCommand_with_provided_Method_value()
            {
                // Arrange
                var sut = Substitute.ForPartsOf<Simple>();
                sut.When(x => x.GetData()).DoNotCallBase();
                sut.GetData().Returns("1,2");
    
                // Act
                sut.Execute();
    
                // Assert
                sut.Received().GetData();
    
                sut.Data.Should().Be("1,2");
                sut.Command.Should().Be("1,2,abc");
            }
    
            [Fact]
            public void should_run_GetCommand_with_provided_Property_value()
            {
                
                // Arrange
                var sut = Substitute.ForPartsOf<Simple>();
                sut.When(x => { var data = x.Data; }).DoNotCallBase();
                sut.Data.Returns("1,2");
    
                // Act
                sut.Execute();
    
                // Assert
                sut.Received().GetData();
                _output.WriteLine(sut.Command);
    
                sut.Data.Should().Be("1,2");
                sut.Command.Should().Be("1,2,abc");
            }
    
        }
    
        public class Simple : ISimple
        {
            public Simple(){}
    
            // TODO: Would like to make this private and use the static call to get an instance
            public Simple(string inputFile, string data)
            {
                InputFile = inputFile;
                InputData = data;
                
                // TODO: Would like to call execute here, but not sure how it will work with testing.
            }
    
            public virtual string GetData()
            {
                // Assume some manipulations are done
                return InputData;
            }
    
            // TODO: Would like to make this private
            public void Execute()
            {
                Data = GetData();
                GetCommand();
                // Other private methods
            }
    
            private void GetCommand()
            {
                Command = Data + ",abc";            
            }
    
            string InputData { get; set; }
    
            public string InputFile { get; private set; }
            
    
            public virtual string Data { get; private set; }
            public string Command { get; private set; }
    
    
            // Using this, so that if I need I can easliy switch to a different concrete class
            public ISimple GetNewInstance(string inputFile, string data)
            {
                return new Simple(inputFile, data);
            }
            
        }    
        
        public interface ISimple
        {
            string InputFile { get; }   // TODO: Would like to use FileInfo instead, but haven't figured out how to test.  Get an error of FileNot found through AutoFixture
            string Data { get; }
            string Command { get; }
    
            void Execute();
        }
    
    }
