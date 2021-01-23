    public class Animal
    {
        public static Enum AnimalType
        {
             Dog,
             Cat
        }  
    
        private _animalType;
    
        public Animal(Enum AnimalType type)
        {
             AnimalType = _animalType;
        }
        
        public bool isOfTtype(Enum AnimalType type)
        {
            return _animalType == type ? true : false;
        }
        
    }
    
    public someothermethod()
    {
        //doing inclusion
        If(MyAnmialObject.isOfTtype(Animal.AnimalType.Dog))
        {
            //if type matches
        }
    
        //Doing exclusion
        If(!MyAnmialObject.isOfTtype(Animal.AnimalType.Dog))
        {
            //if type does not match
        }
    }
