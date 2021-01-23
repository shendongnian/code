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
    public ActionResult Create(ConfigurationCollection con, int[] optionsValuesIds)
    {
        db.ConfigurationCollection.Add(con);
        foreach (optionValueId in optionsValuesIds) 
        {
           Config_OptionVal cnfOpt = new Config_OptionVal();
           cnfOpt.ConfigurationCollection = con;
           cnfOpt.OptionValueID = optionValueId;
           db.Config_OptionVal.Add(cnfOpt);
        }
        db.SaveChanges();
    }
