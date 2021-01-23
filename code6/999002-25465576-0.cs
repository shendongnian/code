    var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
    var fs = FSDirectory.Open("test.index");
    //Index a Test Document
    IndexWriter wr = new IndexWriter(fs, analyzer, true, IndexWriter.MaxFieldLength.LIMITED);
    var doc = new Document();
    doc.Add(new Field("Model", "FORD", Field.Store.YES, Field.Index.NOT_ANALYZED));
    doc.Add(new Field("Model", "HONDA", Field.Store.YES, Field.Index.NOT_ANALYZED));
    doc.Add(new Field("Model", "SUZUKI", Field.Store.YES, Field.Index.NOT_ANALYZED));
    doc.Add(new Field("Text", @"What if i was to search the contents of an entire page, looking for a phrase? such as ""please help me""?", 
                        Field.Store.YES, Field.Index.ANALYZED));
    wr.AddDocument(doc);
    wr.Commit();
    var reader = wr.GetReader();
    var searcher = new IndexSearcher(reader);
    //Use TermQuery for "NOT_ANALYZED" fields
    var result = searcher.Search(new TermQuery(new Term("Model", "FORD")), 100);
    foreach (var item in result.ScoreDocs)
    {
        Console.WriteLine("1)" + reader.Document(item.Doc).GetField("Text").StringValue);
    }
    //Use QueryParser for "ANALYZED" fields
    var qp = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "Text", analyzer);
    result = searcher.Search(qp.Parse(@"""HELP ME"""), 100);
    foreach (var item in result.ScoreDocs)
    {
        Console.WriteLine("2)" + reader.Document(item.Doc).GetField("Text").StringValue);
    }
