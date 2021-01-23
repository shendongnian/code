    var text = @"What if i was to search the contents of an entire page, looking for a phrase? such as ""please help me""?";
    var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30 );
    //var analyzer = new WhitespaceAnalyzer();
    //var analyzer = new KeywordAnalyzer();
    //var analyzer = new SimpleAnalyzer();
            
    var ts = analyzer.TokenStream("", new StringReader(text));
    var termAttr = ts.GetAttribute<ITermAttribute>();
            
    while (ts.IncrementToken())
    {
        Console.Write("[" + termAttr.Term + "] " );    
    }
