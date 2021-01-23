    public class BandVM
    {
      [Display(Name = "Music style")]
      [Required(ErrorMessage = "Please select a style")]
      public string SelectedMusicStyle { get; set; }
      public SelectList MusicStyleList { get; set; }
      ....
    }
