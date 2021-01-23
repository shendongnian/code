    namespace InterfacesStuff
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var someClass1 = new SomeClass {ComparedValue = 1};
                var someClass2 = new SomeClass {ComparedValue = 2};
    
                //someClassObject defined as SomeClass
                //object someClassObject = new SomeClass { ComparedValue = 2 };
    
                //someClassObject defined as anything else but SomeClass
                object someClassObject = 5;
    
                int comparisonSomeClassBySomeClass = someClass1.CompareTo(someClass2);
    
                int comparisonSomeClassByObject = someClass1.CompareTo(someClassObject);
            }
        }
    
    
        public class SomeClass : IComparable, IComparable<SomeClass>, IEquatable<string>, IEquatable<int>,
            IEquatable<double>
        {
            public int ComparedValue;
    
            public int CompareTo(object obj)
            {
                var presumedSomeClassObject = obj as SomeClass;
    
                if (presumedSomeClassObject != null)
                {
                    if (ComparedValue <= ((SomeClass) obj).ComparedValue)
                        return -1;
                }
    
                return 0;
            }
    
            public int CompareTo(SomeClass other)
            {
                if (ComparedValue <= other.ComparedValue)
                    return -1;
    
                return 0;
            }
    
            public bool Equals(double other)
            {
                throw new NotImplementedException();
            }
    
            public bool Equals(int other)
            {
                throw new NotImplementedException();
            }
    
            public bool Equals(string other)
            {
                throw new NotImplementedException();
            }
        }
    }
