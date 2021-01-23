    class Translation
    {
        public int langid { get; set; }
        public string originalword { get; set; }
        public int langid2 { get; set; }
        public string translationword { get; set; }
    }
    static void Test()
    {
        var translation = new List<Translation>
        {
            new Translation { originalword = "group", translationword = "bunch" },
            new Translation { originalword = "group", translationword = "set" },
            new Translation { originalword = "suite", translationword = "group" },
        }
        .AsQueryable();
        var s1 = GetSynonyms(translation, "group").ToList();
        var s2 = GetSynonyms(translation, "suite").ToList();
        var s3 = GetSynonyms(translation, "bunch").ToList();
        var s4 = GetSynonyms(translation, "set").ToList();
        var s5 = GetSynonyms(translation, "blah").ToList();
    }
