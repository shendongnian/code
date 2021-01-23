        public interface IPet
        {
            string Name { get; set; }
        }
        public class Cat : IPet
        {
            public Cat(string name)
            {
                Name = name;
            }
            public string Name {get; set; }
        }
