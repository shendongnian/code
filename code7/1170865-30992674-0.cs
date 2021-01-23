    using Resources;  //<<-- This line
    
    namespace Concordia_CRM.Models
    {
        public class SolicitudDemo
        {
            [Required]
            [Display(Name = "SD_NombreEmpresa", ResourceType = typeof(Resource))]
            public string NombreEmpresa { get; set; }
    
    ...
    }
