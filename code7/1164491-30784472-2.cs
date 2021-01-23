    public class Empresa 
    {
        public string Nombre { get; set; }
        public string NIT { get; set; }
        public string NombreRepresentanteLegal { get; set; }
        public string TelefonoRepresentanteLegal { get; set; }
        public string NombreContacto { get; set; }
        public string TelefonoContacto { get; set; }
    
        [Column(TypeName="xml")]
        public string ExtraProperties { get; set; }
        [NotMapped]
        public XElement ExtraPropertiesElement
        {
            get { return XElement.Parse(ExtraProperties ); }
            set { ExtraProperties = value.ToString(); }
        }
    }
