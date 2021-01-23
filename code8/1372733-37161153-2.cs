    using System.ComponentModel.Composition;
    namespace AnimalModels
    {
        [Export(typeof(Cat))]
        public class Cat
        {
            public string Name { get; set; }
        }
    }
