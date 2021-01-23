    public class ProjectDetailsViewModels
    {
        [Key]
        public int pkiProjectID { get; set; }
        public string ProjectName { get; set; }  
        public string DesignerName { get; set; }
        public string ProjectType { get; set; }
        public string FluidType { get; set; }
        public string PipeMaterial { get; set; }
    }
