    interface IAnimal
    {
        Teeth Teeth { get; } // READ ONLY
    }
    class Mouse : IAnimal
    {
        private SmallTeeth smallTeeth;
        public SmallTeeth Teeth 
        {
            get { return smallTeeth; }
        }
        Teeth IAnimal.Teeth { get { return this.Teeth; } }
    }
