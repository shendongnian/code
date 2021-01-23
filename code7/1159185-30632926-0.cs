    public class Entidad
    {
        // stuff...
        public IEnumerable<CampoAdicional> CamposAdicionales 
        { 
           get { return CampoAdicional.GetAll(this); }
        }
    }
    public class CampoAdicional
    {
        [Key]
        public int Id { get; set; }
        public string NombreCampo { get; set; }
        public virtual Tiposcampo TipoCampo { get; set; }
        protected string EntidadType { get; set; }
        // You will need some mapping between Type and the EntidadType string
        // that will be stored in the database. 
        // Maybe Type.FullName and Type.GetType(string)?
        protected Type MapEntidadTypeToType();
        protected string MapTypeToEntidadType(Type t);
        [NotMapped]
        public Type 
        {            
            get { return MapEntidadTypeToType(); }
            // maybe also check that Entidad.IsAssignableFrom(value) == true
            set { EntidadType = MapTypeToEntidadType(value); }
        }
        public static IEnumerable<CampoAdicional> GetAll(Entidad ent)
        {
            return context.CampoAdicionals
                .Where(a => a.EntidadType == MapTypeToEntidadType(ent.GetType()));
        }
    }
