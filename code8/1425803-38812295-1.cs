    public class UnitTest
        {
            [TestMethod,Isolated]
            public void GetDomainFakeName_willReturnFakeName()
            {
                var fakeDomain = Isolate.Fake.NextInstance<Domain>();
                Isolate.WhenCalled(() => System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain()).WillReturn(fakeDomain);
                Isolate.WhenCalled(() => fakeDomain.Name).WillReturn("TestDomain");
    
                var result = ClassUnderTest.SomeMethod();
    
                Assert.AreEqual("TestDomain", result);
            }
        }
    
        public class ClassUnderTest
        {
            public static string SomeMethod()
            {
              return System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain().Name;
            }
        }
