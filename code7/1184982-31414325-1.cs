    private void DoSomethingWithACustomAnimal(IAnimal myAnimal)
    {
        // This works fine
        MessageBox.Show(myAnimal.NameOfAnimal);
        myAnimal.Eat();
        var feathered = myAnimal as IHaveFeathers;
        if (feathered != null)
        {
            MessageBox.Show(feathered.NumberOfFeathers);
        }
        
        var flier = myAnimal as IFly;
        if (flier != null)
        {
            flier.Fly();
        }
    }
