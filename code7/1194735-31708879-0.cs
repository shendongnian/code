    public class Vehicle
    {
        public string Id { get; set; }
        public string ModelId { get; set; }
        
        public Model Model { get; set; }
    }
    
    public class Model 
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }
