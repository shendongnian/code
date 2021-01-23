    using System;
    using NUnit.Common;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace UnitTests
    {
        [TestFixture]
        public class UnitTest1
        {
            [Test]
            public void TestMethod1()
            {
                 
                var types = new[] { typeof(int), typeof(float), typeof(Guid), typeof(UnitTest1) };
    
                Dictionary<Guid, object> dictionary = types.Select(x => Activator.CreateInstance(x)).ToDictionary(y => Guid.NewGuid());
    
                types.ToList().ForEach(t =>
                    Assert.IsTrue(dictionary.Any(x => x.Value.GetType() == t))
                );
                Assert.IsTrue(dictionary.ElementAt(0).Value is int);
            }
        }    
    }
