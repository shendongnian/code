     public class eAuthorInfo //represents all info stored in eAuthors
     {
         public int Paper_ID { get; set; }
         public int CoAuthor_ID { get; set; }
         public int Venue_ID { get; set; }
         public int Paper_Category { get; set; }
         public int Year { get; }
         public int Publisher_ID { get; }
         //etc.
     }
     //bring all info from database   
     IEnumerable<eAuthorInfo> eAuthors = GetAllInfoFromDB();
     //Now filter and project what you need
     public static IEnumerable<PaperInfo> GetGetPaperInfoBetweenYears(this List<eAuthorInfo> eAuthors, int lower, int upper)
     {
         return from eAuthor in eAuthors
                where (eAuthor.Year >= lower && eAuthor.Year < upper)
                select new PaperInfo() { Paper_ID = eAuthor.Paper_ID, CoAuthor_ID = eAuthor.CoAuthor_ID, Paper_Category = eAuthor.Paper_Category, Venue_ID = eAuthor.Venue_ID };
     }
