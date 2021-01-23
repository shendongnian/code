    public interface IAnimal
    {
        string NameOfAnimal { get; set; }
    	void Accept(IAnimalVisitor visitor);
    }
