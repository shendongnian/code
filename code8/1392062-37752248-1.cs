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
    
                Dictionary <Guid, object> dictionary = types.Select(x => Activator.CreateInstance(x)).ToDictionary(y => Guid.NewGuid());
    
                types.ToList().ForEach(t =>
                    Assert.IsTrue(dictionary.Any(x => x.Value.GetType() == t))
                );
    
                Assert.IsTrue(dictionary.ElementAt(0).Value is int);
                Assert.IsTrue(dictionary.ElementAt(1).Value is float);
                Assert.IsTrue(dictionary.ElementAt(2).Value is Guid);
                Assert.IsTrue(dictionary.ElementAt(3).Value is UnitTest1);
    
                dictionary.Add(Guid.NewGuid(), Guid.NewGuid());
    
                Assert.IsTrue(dictionary.ElementAt(4).Value is Guid);
            }
        }    
    }
