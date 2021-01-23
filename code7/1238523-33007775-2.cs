    public class AcademicViewModel
    {
      public string GraduationQualification { get; set; }
      public string GraduationAchievement { get; set; }
      public string PostGraduationQualification { get; set; }
      public string PostGraduationAchievement { get; set; }
      public string ProfessionalAchievement { get; set; }
      public IEnumerable<SelectListItem> GraduationList { get; set; }
      public IEnumerable<SelectListItem> PostGraduationList { get; set; }
    }
