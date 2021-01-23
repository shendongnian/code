    namespace Project.Models
    {
        [Table(Name="Usuario")]
        public class Usuario
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int id { get; set; }
            [Column]
            public string nombre { get; set; }
            [Column]
            public string direccion { get; set; }
            [Column]
            public string telefono { get; set; }
            [Column]
            public string codigoPostal { get; set; }
            [Column]
            public Int32 tipoUsuarioId { get; set; }
            [Column]
            public Int32 ciudadId { get; set; }
    
    
            private EntityRef<Ciudad> _ciudad;
            [Association(Storage = "_ciudad", Name = "FK_USUARIO_CIUDAD", OtherKey = "id", ThisKey = "ciudadId", IsForeignKey = true)]
            public Ciudad ciudad {
                get {return this._ciudad.Entity;}
                set { this._ciudad.Entity = value; }
            }
          
            private EntityRef<TipoUsuario> _tipoUsuario = new EntityRef<TipoUsuario>();
            [Association (Storage="_tipoUsuario",Name="FK_USUARIO_TIPOUSUARIO",OtherKey="id",ThisKey="tipoUsuarioId",IsForeignKey=true)]
            public  TipoUsuario tipoUsuario { 
                get {return this._tipoUsuario.Entity;}
                set { this._tipoUsuario.Entity = value; }
            }
    
        }
