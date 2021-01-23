    public bool AddAnimal(Animal animal)
    {
        bool status = true;
        foreach (Animal TempAnimal in animalList)
        {
            if (TempAnimal.ChipRegistrationNumber == animal.ChipRegistrationNumber)
            {
                status = false;
            }
            else
            {
                status = true;
            }
        }
        if (status)
        {
            animalList.Add(animal);
        }
        return status;
    }
