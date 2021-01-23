        public class Person : IComparable 
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Title { get; set; }
            public List<string> order { get; set; }
            
            public int CompareTo(object _other)
            {
                Person other = (Person)_other;
                int results = 0;
                if (this.Name != other.Name)
                {
                    results = this.Name.CompareTo(other.Name);
                }
                else
                {
                    if (this.Age != other.Age)
                    {
                        results = this.Age.CompareTo(other.Age);
                    }
                    else
                    {
                        results = this.Title.CompareTo(other.Title);
                    }
                }
                return results;
            }
