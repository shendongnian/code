    [Table("Chapter")]
    public class Chapter
    {
        [PrimaryKey, AutoIncrement]
        public int Index { get; set; }
        public string ChapterName { get; set; }
        public int ChapterNo { get; set; }
    }
