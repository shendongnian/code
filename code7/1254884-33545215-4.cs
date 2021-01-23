    public class OptionValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OptionValueID { get; set; }
        public string OptionVal { get; set; }
        public int OptionID { get; set; }
    
        public virtual ICollection<ConfigurationCollection> ConfigurationCollections { get; set; }
        public virtual Option Option { get; set; }
    }
