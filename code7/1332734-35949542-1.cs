    using System.ComponentModels.DataAnnotations;
    
    public class ModelA
    {
        public int Id { get; set; }
    
        [Required(ErrorMessage="You need to enter a name!")]
        [StringLength(40)]
        public string Name { get; set; }
    }
