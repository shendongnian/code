    public class BookMark
    {
        static int _number;
        public BookMark() { Number = ++_number; }
        public int Number { get; private set; }
        public string Title { get; set; }
        public string PageNumberString { get; set; }
        public int PageNumberInteger { get; set; }
        public static void ResetNumber() { _number = 0; }
        // bookmarks title may have illegal filename character(s)
        public string GetFileName()
        {
            var fileTitle = Regex.Replace(
                Regex.Replace(Title, @"\s+", "-"), 
                @"[^-\w]", ""
            );
            return string.Format("{0:D4}-{1}.pdf", Number, fileTitle);
        }
    }
