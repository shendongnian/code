<s> 
    public class UpdateModel : BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }
        public DateTime Updated { get; set; }
    }
 </s>
