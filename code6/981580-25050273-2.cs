    public class KeywordsIndex : AbstractIndexCreationTask<Record, KeywordsIndex.Result>
    {
        public KeywordsIndex()
        {
            Map = records => from record in records
                from keyword in record.Keywords
                select new 
                    {
                        Keyword = keyword
                    }
        }
        public class Result
        {
            public Keyword Keyword { get; set; }
        }
    }
