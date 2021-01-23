     public class BookViewModel
        {
            public string BookId { get; set; }
    
            public string Name { get; set; }
    
            public CultureViewModel Culture { get; set; }
        }
    
     public class CultureViewModel
        {
            public string NativeName { get; set; }
    
            public string TwoLetterCode { get; set; }
        }
