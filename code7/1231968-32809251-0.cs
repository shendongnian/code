     public bool AddAnimal(Animal animal)
        {
            bool status = false;
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
     animalList.Add(animal);
            return status;
        }
