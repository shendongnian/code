    public partial class tpintDB
    {
        public int id_tpint { get; set; }
        public string libelle { get; set; }
        public string desc_tpint { get; set; }
        public virtual ICollection<intDB> intDBs { get; set; }
    }
