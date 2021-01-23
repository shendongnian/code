    class Ingredient {
        Ingredient(decimal cost) { Cost = cost; }
        public double Cost { get; set; }
    }
    class Sauce : Ingredient {
        Sauce(decimal cost) { Cost = cost; }
        // This hides Ingredient.Cost.
        // You probably don't want that.
        public double Cost { get; set; }
    }
