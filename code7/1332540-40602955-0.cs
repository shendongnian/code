    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;
    using Xunit.Abstractions;
    using Xunit.Sdk;
    using XunitCategoriesSample.Traits;
    
    namespace XunitCategoriesSample.Traits
    {
        public class CategoryDiscoverer : ITraitDiscoverer
        {
            public const string KEY = "Category";
    
            public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
            {
                var ctorArgs = traitAttribute.GetConstructorArguments().ToList();
                yield return new KeyValuePair<string, string>(KEY, ctorArgs[0].ToString());
            }
        }
    
        //NOTICE: Take a note that you must provide appropriate namespace here
        [TraitDiscoverer("XunitCategoriesSample.Traits.CategoryDiscoverer", "XunitCategoriesSample")]
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
        public class CategoryAttribute : Attribute, ITraitAttribute
        {
            public CategoryAttribute(string category) { }
        }
    }
    
    namespace XunitCategoriesSample
    {
        public class Class1
        {
            [Fact]
            [Category("Jobsearcher")]
            public void PassingTest()
            {
                Assert.Equal(4, Add(2, 2));
            }
    
            [Fact]
            [Category("Employer")]
            public void FailingTest()
            {
                Assert.Equal(5, Add(2, 2));
            }
    
            int Add(int x, int y)
            {
                return x + y;
            }
        }
    }
