            public List<Brands> Brands { get; set; }
            public List<Products> Products { get; set; }
            public List<Search_Results> Search_Results { get; set; }
        }
        class Language
        {
            public string en { get; set; }
            public string tr { get; set; }
            public string de { get; set; }
            public string bg { get; set; }
            public string el { get; set; }
            public string uk { get; set; }
            public string nl { get; set; } 
        }
        class Brands : Language
        {
        }
        class Products : Language
        {
        }
        class Search_Results : Language
        {
        }
