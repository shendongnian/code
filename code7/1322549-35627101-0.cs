    public class Caracteristic
    {
        #region Properties
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]        
        public string Name { get; set; }
        public string Description { get; set; }
        public int CaracteristicGroupId { get; set; }
        public virtual CaracteristicGroup Group { get; set; }
        #endregion
    }
