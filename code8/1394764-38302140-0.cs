    IndexSettings indexSettings = new IndexSettings();
    indexSettings.NumberOfReplicas = 1;
    indexSettings.NumberOfShards = 1;
    
    CustomAnalyzer exclamation = new CustomAnalyzer();
    exclamation.Tokenizer = "exclamationTokenizer";
    exclamation.Filter = new List<string> {"synonym"};
    indexSettings.Analysis.Tokenizers.Add("exclamationTokenizer", new PatternTokenizer
    {
    });
    
    indexSettings.Analysis.Analyzers.Add("exclamation", exclamation);
    indexSettings.Analysis.TokenFilters.Add("synonym", new SynonymTokenFilter { Synonyms = new[] { "tire => tyre", "aluminum => aluminium" }, IgnoreCase = true, Tokenizer = "whitespace" });
