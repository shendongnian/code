        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                MyClassTestWrapped t = new MyClassTestWrapped();
                Assert.IsTrue(t.MyPrivateMethod(...));
                Assert.IsTrue(t.MyMethod(...));
                MockFactory _factory = new MockFactory();
		        Mock<MyClassTestWrapped> mock;
                mock = _factory.CreateMock<MyClass>();
                mock.Expects.One.MethodWith(d => d.MyPrivateMethod());  // do the nmock magic here
            }
        }
        
        public class MyClass : IMyClassInterface
        {
            public List<int> MyMethod(int a, int b)
            {
                MyPrivateMethod(a, b, ref varList, ref someVal);
            }
    // here change to protected
            protected void MyPrivateMethod(int a, int b, ref List<int> varList, ref double someval)
            {
            }
        }
        
        public interface IMyClassInterface
        {
        
        }
        
        public class MyClassTestWrapped : MyClass
        {
            public List<int> MyMethod(int a, int b)
            {
                base.MyMethod(a, b);
            }
        
            public List<int> MyPrivateMethod(int a, int b,ref List<int> varList, ref double someval)
            {
                base.MyPrivateMethod(a, b, ref varList, ref someval);
            }
        
        }
