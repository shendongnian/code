    [HttpPost]
    public IHttpActionResult SaveActivity(ActivityEditForm form);
    {
        // cut
    }
    public class ActivityEditForm
    {
        public int? Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
