    private static Dictionary<int, Language> GetLanguagesDictionary()
    {
            var dict = new Dictionary<int, Language>();
            using (var db = new DBContext())
            {
                var q = db.Languages;
                foreach (var rec in q)
                {
                    dict.Add(rec.ID, new Language(rec));
                }
            }
            return dict;
    }
    public static Lazy<Dictionary<int, Language>> GetLanguages = 
        new Lazy<Dictionary<int, Language>>(() => GetLanguagesDictionary(), true);
