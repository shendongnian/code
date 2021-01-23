    public class Child {
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [ForeignKey("ParentRefId")]
    public int ParentId { get; set; }
    public Parent Parent { get; set; }
    }
