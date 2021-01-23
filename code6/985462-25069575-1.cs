    public class TestViewModel
    {
        public int Id { get; set; }
        
        [AllowHtml]
        public string StartDescription { get; set; }
        [AllowHtml]
        public string EndDescription { get; set; }
    }
