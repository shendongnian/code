    public class ContentVM
    {
      public string LanguageCode { get; set; }
      public string LanguageName { get; set; } // used for the label
      [Required]
      public string ContentName { get; set; }
    }
