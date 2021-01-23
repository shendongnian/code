    public enum UsedConstructor { Default, Name, NameAndAge };
    public class Dog
    {
        UsedConstructor UsedConstructor { get; }
        public string Name;
        public int Age;
        public Dog()
        {
            UsedConstructor = UsedConstructor.Default;
        }
        public Dog(string n, int age)
        {
            UsedConstructor = UsedConstructor.NameAndAge;
            this.Name = n;
            this.Age = age;
        }
        public Dog(string n)
        {
            UsedConstructor = UsedConstructor.Name;
            this.Name = n;
        }
