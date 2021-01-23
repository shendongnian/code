    public abstract class Animal
    {
        public Animal(string animalName)
        {
            this.Name = animalName;
        }
        //insert properties and methods which all aimals share here
        public string Name { get; set; }
    }
    public class CibetCat : Animal
    {
        public CibetCat() : base("CibetCat")
        {
        }
        //insert properties and methods which all CibetCats share here
    }
