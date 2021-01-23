    // I used the same namespace for convenience
    namespace NUnit.Framework
    {
        public class NameAttribute  : NUnitAttribute, IApplyToTest
        {
            public NameAttribute(string name)
            {
                Name = name;
            }
            
            public string Name { get; set; }
    
            public void ApplyToTest(Test test)
            {
                test.Properties.Add("Name", Name);
            }
        }
    }
