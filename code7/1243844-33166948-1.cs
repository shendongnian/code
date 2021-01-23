        class Person
        {
            public int Age { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return String.Format("Name: {0} Age: {1}.", this.Name, this.Age);
            }
        }
