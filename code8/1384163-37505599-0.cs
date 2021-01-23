    //using System.ComponentModel.DataAnnotations.Schema
    public class Object1
    {
    
        public int Property1{ get; set; }
        public string Property2 { get; set; }
            
        //Foreign key for Object2
        public int FK_Object2_Property { get; set; }
    
        [ForeignKey("FK_Object2_Property")]
        public Object2 Object2 { get; set; }
    }
    public class Object2
    {
      
        public int Property1{ get; set; }
        public string Property2 { get; set; }
        
        public ICollection<Object1> Objects { get; set; }
    }
