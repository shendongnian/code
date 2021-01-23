    public class DogTrainer : Trainer, ITrainer
    {
    	public DogTrainer(IAnimal animal)
    		: base(animal)
    	{ }
    
    	public new string Train()
    	{
    		return $"Speak Ubu, Speak : {Animal.Speak()}";
    	}
    }
