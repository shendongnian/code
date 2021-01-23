    public class Bird : IAnimal
    {
        public Bird()
        {
            NameOfAnimal = "Bob the Bird";
            NumberOfFeathers = 100;
        }
    	
        public string NameOfAnimal { get; set; }
        public int NumberOfFeathers { get; protected set; }
        public string SomeOtherBirdSpecificProperty { get; protected set; }
    	
    	void Accept (IAnimalVisitor visitor)
    	{
    	    visitor.VisitBird(this);
    	}
    }
    
    public class Fish : IAnimal
    {
        public Fish()
        {
            NameOfAnimal = "Jill the Fish";
            DoesFishHaveSharpTeeth = true;
        }
    	
        public string NameOfAnimal { get; set; }
        public bool DoesFishHaveSharpTeeth { get; protected set; }
        public string SomeOtherFishSpecificProperty { get; protected set; }
    	
    	void Accept (IAnimalVisitor visitor)
    	{
    	    visitor.VisitFish(this);
    	}
    }
