    class NamedAnimal : Animal, IComparable<NamedAnimal>
    {
        public string AnimalName { get; set; }
       
        public NamedAnimal(): base ()
        {
           //first constructor with the variables inherited from class Animal
        }
        public NamedAnimal() : base()
        {
            //2nd constructor with the variables inherited + the AnimalName
        }
        public virtual string GetNotes()
        {
            return "No notes available";
        }
       public int CompareTo(NamedAnimal otherAnimalName)
        {
            return AnimalName.CompareTo(otherAnimalName.AnimalName);
        }   
    }
