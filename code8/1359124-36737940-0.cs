    class Person : ICloneable 
    {     
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Position { get; set; } 
        public int Age { get; set; } 
        
        public Person Clone() 
        { 
            return (Person)this.MemberwiseClone(); 
        } 
         
        object ICloneable.Clone() 
        { 
            return this.Clone(); 
        } 
    
    }
