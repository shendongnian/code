    class Horse
    {
        public int Age{ get; private set };
        public int Hunger { get; private set; }
        public string Name { get; private set; } 
        public Horse(string name)
        {  
            Name = name;
            Age = 0;
            Hunger = 0;
        }     
    
        public bool IsDead() 
        {
           return Hunger >= 100 || Age > 3650;
        }
        void PassDay()
        {
           Age = Age + 1;
           Hunger = Hunger + 1;
        }
    
        void Feed()
        {
           Hunger = 0;
        }
        // etc.
    }
    
