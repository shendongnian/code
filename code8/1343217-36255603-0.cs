    public class VMRoundMaterial
    {
        [Required]
        [Display(Name="Outside Diameter")]
        public double OuterDiameter { get; set; }
        [Display(Name="Material")]
        public int MaterialId { get; set; }
        public IEnumerable<SelectListItem> Materials  { get; set; }
    }
