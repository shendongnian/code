    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    
    namespace StackOverflowSandbox
    {
        public class ToDictionaryTests
        {
            [Test]
            public void ItShouldWork()
            {
                // Arrange
                var dapperResult = new
                {
                    UPPER = 1,
                    lower = 2
                };
    
                // Act
                var dictionary = dapperResult.ConvertToDictionary();
    
                // Assert
                Assert.That(dictionary["Upper"], Is.EqualTo(1));
                Assert.That(dictionary["Lower"], Is.EqualTo(2));
            }
        }
    
        public static class ObjectExtensions
        {
            private static readonly StringComparer ToDictionaryDefaultComparer =
                StringComparer.OrdinalIgnoreCase;
    
            /// <summary>
            /// Converts an object's properties that can be read
            /// to an IDictionary.
            /// </summary>
            public static IDictionary<string, object> ConvertToDictionary(
                this object @this,
                StringComparer comparer = null)
            {
                // The following is adapted from: 
                // https://stackoverflow.com/a/15698713/569302
                var dictionary = new Dictionary<string, object>(
                    comparer ?? ToDictionaryDefaultComparer);
                foreach(var propertyInfo in @this.GetType().GetProperties())
                {
                    if (propertyInfo.CanRead && 
                        propertyInfo.GetIndexParameters().Length == 0)
                    {
                        dictionary[propertyInfo.Name] = 
                            propertyInfo.GetValue(@this, null);
                    }
                }
    
                return dictionary;
            }   
        }
    }
