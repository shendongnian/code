    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var data = new[]
                {
                    new SomeClass { SomeId = 1, AnotherId = 1, SomeOtherId = 1, Timestamp = 10 },
                    new SomeClass { SomeId = 1, AnotherId = 1, SomeOtherId = 1, Timestamp = 20 }, // Duplicate
                    new SomeClass { SomeId = 1, AnotherId = 2, SomeOtherId = 2, Timestamp = 30 },
                    new SomeClass { SomeId = 1, AnotherId = 2, SomeOtherId = 2, Timestamp = 35 }, // Duplicate
                    new SomeClass { SomeId = 2, AnotherId = 4, SomeOtherId = 4, Timestamp = 40 },
                    new SomeClass { SomeId = 3, AnotherId = 2, SomeOtherId = 2, Timestamp = 50 },
                    new SomeClass { SomeId = 1, AnotherId = 1, SomeOtherId = 1, Timestamp = 50 } // Duplicate
                };
    
                var distinctList = data
                            .OrderBy(x => x.Timestamp)
                            .Distinct(new SomeClassComparer())
                            .ToList();
                }
    
            public class SomeClass
            {
                public int SomeId { get; set; }
                public int AnotherId { get; set; }
                public int SomeOtherId { get; set; }
                public int Timestamp { get; set; }
            }
    
            public class SomeClassComparer : IEqualityComparer<SomeClass>
            {
                public bool Equals(SomeClass x, SomeClass y)
                {
                    if (ReferenceEquals(x, y))
                    {
                        return true;
                    }
    
                    //Check whether any of the compared objects is null.
                    if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                    {
                        return false;
                    }
    
                    //Check whether the SomeClass's properties are equal.
                    return x.SomeId == y.SomeId &&
                           x.AnotherId == y.AnotherId &&
                           x.SomeOtherId == y.SomeOtherId;
                }
    
                public int GetHashCode(SomeClass someClass)
                {
                    //Check whether the object is null
                    if (ReferenceEquals(someClass, null))
                    {
                        return 0;
                    }
    
                    //Get hash code for the fields
                    var hashSomeId = someClass.SomeId.GetHashCode();
                    var hashAnotherId = someClass.AnotherId.GetHashCode();
                    var hashSomeOtherId = someClass.SomeOtherId.GetHashCode();
    
                    //Calculate the hash code for the SomeClass.
                    return (hashSomeId ^ hashAnotherId) ^ hashSomeOtherId;
                }
            }
        }
    }
