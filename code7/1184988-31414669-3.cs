    public class AnimalPrinter : IAnimalVisitor
    {
        private void VisitAnimal(IAnimal animal)
    	{
    	    MessageBox.Show(animal.NameOfAnimal);
    	}
    
        void VisitBird(Bird bird)
    	{
    	    visitAnimal(bird);
    		MessageBox.Show(bird.NumberOfFeathers);
    	}
    	
    	void VisitFish(Fish fish)
    	{
    	    visitAnimal(fish);
    		MessageBox.Show(fish.DoesFishHaveSharpTeeth);
    	}
    }
