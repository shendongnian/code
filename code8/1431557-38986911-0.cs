    public class EditArticleViewModel
    {
        public Guid Id { get; set; }
        ....
        [Display(Name = "Tags")]
        public IEnumerable<string> SelectedTags { get; set; }
        public IEnumerable<SelectListItem> TagsList { get; set; }
    }
