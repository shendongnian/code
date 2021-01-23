    public class BlogEntryModel
    {
        public int Id { get; set; }
        public DateTime BlogEntryDate { get; set; }
        public string BlogEntryTitle { get; set; }
        public string BlogEntrySummary { get; set; }
        public string BlogEntryContent { get; set; }
        public string BlogEntryPublishedBy { get; set; }
        public bool BlogEntryPublished { get; set; }
        public int BlogCategoryId { get; set; }
    }
