    public class TestClassUnderTest
    {
        public ClassUnderTest Target { get; set; }
        [SetUp]
        public void before_each_test()
        {
            Target = new ClassUnderTest();
        }
    
        // Now each behavior has its own class with the system under test available through the Target property
        public class ThisMethod : TestClassUnderTest
        {
            [Test]
            [ExpectedException(typeof(Exception))]
            public void throws_if_null_is_passed()
            {
                Assert.IsTrue(false); // make it fail at first
            }
    
            [Test]
            public void returns_true_if_string_is_empty()
            {
                Assert.IsTrue(false); // make it fail at first
            }
        }
    
        public class ThatMethod : TestClassUnderTest
        {
            [Test]
            public void returns_argument_concatenated_with_timestamp()
            {
                Assert.IsTrue(false); // make it fail at first
            }
        }
    }
