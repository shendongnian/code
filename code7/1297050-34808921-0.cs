    class Ingredient
    {
        public int Nom;
        public virtual void TellName()
        {
            Console.WriteLine("Ingredient");
        }
    }
    class Sauce : Ingredient
    {
        public override void TellName()
        {
            Console.WriteLine("Sauce");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var ingredientList = new List<Ingredient> {new Ingredient(), new Sauce()};
            foreach (var ingredient in ingredientList)
            {
                ingredient.TellName();
            }
        }
    }
