    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace UnitTestProject2
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void TestMethod1()
            {
                var disposable = new DisposableObject();
                disposable.DoSomething();
            }
            [TestMethod]
            public void TestMethod2()
            {
                using (var disposable = new DisposableObject())
                {
                    disposable.DoSomething();
                }
            }
        }
        public class DisposableObject : IDisposable
        {
            public void Dispose()
            {
                // dispose here
            }
            public void DoSomething()
            {
                // do something here
            }
        }
    }
