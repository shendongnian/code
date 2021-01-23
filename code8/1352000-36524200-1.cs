    public class Program
        {
            public Titles Titles { get; set; }
            public string Title { get; set; }
            public string GetTitle()
            {
                if (Titles != null)
                {
                    return Titles.Title;
                }
                else
                {
                    return Title;
                }
            }
            
        }
