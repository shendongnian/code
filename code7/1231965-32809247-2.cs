    public bool AddAnimal(Animal animal)
    {
        if (!animalList.Any(a => a.ChipRegistrationNumber == animal.ChipRegistrationNumber))
        {
            animalList.Add(animal);
            return true;
        }
        return false;
    }
