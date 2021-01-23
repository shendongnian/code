        Query query = MultiFieldQueryParser.Parse(Lucene.Net.Util.Version.LUCENE_30, "Shoes", new String[] { "SHOPPING" }, new SimpleAnalyzer());
        
        Query queryOrig = parser.Parse("shoes");
        Query queryOrig2 = parser.Parse("accessories");
        
        var booleanQuery= new BooleanQuery();
        booleanQuery.Add(queryOrig, Occur.MUST);
        booleanQuery.Add(queryOrig2, Occur.MUST_NOT);
    
        hits = indexSearcher.search(booleanQuery);
