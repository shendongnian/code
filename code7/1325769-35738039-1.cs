    class Cat : Animal
    {
        public Cat(double weight, string name)
        {
            this.weight = weight;
            this.name = name;
        }
        private double weight;
        private string name;
        public override string ToString()
        {
            return "I'm the cat " + name + " and I weight " + weight;
        }
    }
