    public class PostViewModel // its for a single post - not plural?
    {
      public int ID { get; set; }
      [Required(ErrorMessage = "Please enter a title")]
      public string Title { get; set; }
      [Display(Name = "Tags")] // plus [Required] is at least one tag must be selected
      public List<int> SelectedTags { get; set; }
      public SelectList TagsList { get; set; }
      // Its unclear if you really need the following 2 properties (see notes)
      [Display(Name = "User")]
      [Required(ErrorMessage = "Please select a user")]
      public int UserID { get; set; }
      public SelectList UserList { get; set; }
    }
