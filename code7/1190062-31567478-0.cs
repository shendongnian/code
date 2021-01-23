    public class PestanasPorEntidad
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        //Add this to specify a unique index for both Orden...
        [Index("IX_OrdenAndEntitad", 1, IsUnique = true)]
        public int Orden { get; set; }
        public string ClaseFontAwesome { get; set; }
        //...and also EntitadId
        [Index("IX_OrdenAndEntitad", 2, IsUnique = true)]
        public int EntitadId { get; set; }
        public virtual Entidad Entidad { get; set; }
    }
