    public class VideoModels
    { 
    [Required]
    public int Id { get; set; } 
    public virtual ProfileModels Profile { get; set; }  
    }
