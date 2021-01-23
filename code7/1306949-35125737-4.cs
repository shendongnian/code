    public partial class Person
    {
        public Person GetPersonWithChindren(int maxAge)
        {
            return new Person
            {
                Age = this.Age,
                Name = this.Name,
                Childrens = this.Childrens != null ? this.Childrens.Where(x => x.Age < maxAge).Select(x => x.GetPersonWithChindren(maxAge)).ToList() : null
            };
        }
    }
