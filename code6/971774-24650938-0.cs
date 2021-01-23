    //explicit interface implementation
    public class Animal : CoreObject, IObjectCopy<Animal>
    {
        Animal IObjectCopy<Animal>.Copy()
        {
            return (Animal) base.Copy();
        }
    }
    //does not require an explicit cast
    IObjectCopy<Animal> animalCopy = myAnimal;
    Animal copiedAnimal = animalCopy.Copy();
    //second option: shadow the original method and cast inside the object
    public class Animal : CoreObject, IObjectCopy<Animal>
    {
        public new Animal Copy()
        {
            return (Animal) base.Copy();
        }
    }
    Animal copy = myAnimal.Copy();
