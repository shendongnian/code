    class Ingredient {
        Ingredient(decimal cost) { Cost = cost; }
        public double Cost { get; set; }
    }
    class Sauce : Ingredient {
        Sauce(decimal cost) { Cost = cost; }
        public double Cost { get; set; }
    }
