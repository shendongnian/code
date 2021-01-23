    class Chemical
    {
        public ICollection<Ingredient> Ingredients { get; set; }
    }
    
    class Ingredient
    {
        public Chemical Chemical { get; set; }
        public Solution Solution { get; set; }
    }
    
    Solution
    {
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Usage> Usages { get; set; }
    }
    
    class Usage
    {
        public Solution Solution { get; set; }
        public Project Project { get; set; }
    }
    
    class Project
    {
        public ICollection<Usage> Usages { get; set; }
    }
