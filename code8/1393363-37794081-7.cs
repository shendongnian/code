	var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
	var directory = new RAMDirectory();
	using (var writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED))
	{
		var doc = new Document();
		doc.Add(new Field("id", "1", Field.Store.YES, Field.Index.NOT_ANALYZED));
		doc.Add(new Field("name", "John Smith", Field.Store.NO, Field.Index.ANALYZED));
		doc.Add(new Field("additionalData", "faster data", Field.Store.NO, Field.Index.ANALYZED));
		writer.AddDocument(doc);
		doc = new Document();
		doc.Add(new Field("id", "2", Field.Store.YES, Field.Index.NOT_ANALYZED));
		doc.Add(new Field("name", "Alan Smith", Field.Store.NO, Field.Index.ANALYZED));
		doc.Add(new Field("additionalData", "faster drive", Field.Store.NO, Field.Index.ANALYZED));
		writer.AddDocument(doc);
		doc = new Document();
		doc.Add(new Field("id", "3", Field.Store.YES, Field.Index.NOT_ANALYZED));
		doc.Add(new Field("name", "Mike Std", Field.Store.NO, Field.Index.ANALYZED));
		doc.Add(new Field("additionalData", "faster check", Field.Store.NO, Field.Index.ANALYZED));
		writer.AddDocument(doc);
	}
	var words = new[] {"John", "data", "check"};
	var parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_30, new[] {"name", "additionalData"}, analyzer);
	var mainQuery = new BooleanQuery();
	foreach (var word in words)
		mainQuery.Add(parser.Parse(word), Occur.SHOULD);
	using (var searcher = new IndexSearcher(directory))
	{
		var results = searcher.Search(mainQuery, null, int.MaxValue, Sort.RELEVANCE);
		var idFieldSelector = new MapFieldSelector("id");
		foreach (var scoreDoc in results.ScoreDocs)
		{
			var doc = searcher.Doc(scoreDoc.Doc, idFieldSelector);
			Console.WriteLine("Found: {0}", doc.Get("id"));
		}
	}
