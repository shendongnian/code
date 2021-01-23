    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    
    namespace UnitTestProject
    {
        [TestClass]
        public class UnitTest
        {
            public class Factorial
            {
                Dictionary<int, long> store = new Dictionary<int, long>();
    
                public long Get(int number)
                {
                    if (store.ContainsKey(number))
                    {
                        return store[number];
                    }
    
                    if (number == 0)
                    {
                        store.Add(0, 1);
                        return 1;
                    }
    
                    var result = number * Get(number - 1);
                    store.Add(number, result);
    
                    return result;
                }
            }
    
         
            [TestMethod]
            public void SomeTest()
            {
                // Arrange
                var target = new Factorial();
                var results = new List<long>();
    
                // Act
                for (int i = 10; i >= 0; i--)
                {
                    results.Add(target.Get(i));
                }
    
                // Assert
            }
        }
    }
