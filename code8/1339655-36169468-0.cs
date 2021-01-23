    public class Person : IEqualityComparer<Person>
        {
            public string UserName { get; set; }
            public int Age { get; set; }
            bool IEqualityComparer<Person>.Equals(Person x, Person y)
            {
                if (x.UserName == y.UserName)
                    return true;
                return false;
            }
            int IEqualityComparer<Person>.GetHashCode(Person obj)
            {
                return base.GetHashCode();
            }
        }
