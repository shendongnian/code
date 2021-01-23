    public class AnimalMessageBoxes : IAnimalVisitor
    {
        private void VisitAnimal(IAnimal animal)
    	{
    	    MessageBox.Show(animal.NameOfAnimal);
    	}
    
        public void VisitBird(Bird bird)
    	{
    	    visitAnimal(bird);
    		MessageBox.Show(bird.NumberOfFeathers);
    	}
    	
    	public void VisitFish(Fish fish)
    	{
    	    visitAnimal(fish);
    		MessageBox.Show(fish.DoesFishHaveSharpTeeth);
    	}
    }
