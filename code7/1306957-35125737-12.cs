    public partial class Person
    {
        public Person GetPersonWithChindren(Func<Person, bool> func)
        {
            return new Person
            {
                Age = this.Age,
                Name = this.Name,
                Childrens = this.Childrens != null
                ? this.Childrens
                    .Where(x => func(x))
                    .Select(x => x.GetPersonWithChindren(func))
                    .ToList()
                : null
            };
        }
    }
