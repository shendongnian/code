    public class TestViewModel
    {
        public int Id { get; set; }
    
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string StartDescription { get; set; }
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string EndDescription { get; set; }
    }
