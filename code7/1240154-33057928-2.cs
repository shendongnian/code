	public interface IPerson
    {
        void EatLunch();
	}
	public interface INameDisclosingPerson : IPerson
    {
        string Name {get; set; }
	}
	public interface ISpy : IPerson
    {
        void DrinkCocktail();
        Package MakeDrop();
	}
