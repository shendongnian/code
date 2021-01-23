    [TestClass]
	public class UnitTest6
	{
		[TestMethod]
		public void TestShopping()
		{
			var writer = CreateIndex();
			Add(writer, "Shoes for sale");
			Add(writer, "Great bargain on shoes and accessories.");
			Add(writer, "Buy cheap Shoes, Sneekers and Heels!");
			writer.Flush(true, true, true);
			var searcher = new IndexSearcher(writer.GetReader());
			var result1 = Search(searcher, "shoes NOT accessories");
			Assert.AreEqual(2, result1.Count);
			Assert.IsTrue(result1.Contains("Shoes for sale"));
			Assert.IsTrue(result1.Contains("Buy cheap Shoes, Sneekers and Heels!"));
			writer.Dispose();
		}
		[TestMethod]
		public void TestShopping2()
		{
			var writer = CreateIndex();
			Add(writer, "Shoes for sale");
			Add(writer, "Great bargain on shoes and accessories.");
			Add(writer, "Buy cheap Shoes, Sneekers and Heels!");
			writer.Flush(true, true, true);
			var searcher = new IndexSearcher(writer.GetReader());
			var query1 = new TermQuery(new Term("shopping", "shoes"));
			var query2 = new TermQuery(new Term("shopping", "accessories"));
			var booleanQuery = new BooleanQuery();
			booleanQuery.Add(query1, Occur.SHOULD);
			booleanQuery.Add(query2, Occur.MUST_NOT);
			var result1 = Search(searcher, booleanQuery);
			Assert.AreEqual(2, result1.Count);
			Assert.IsTrue(result1.Contains("Shoes for sale"));
			Assert.IsTrue(result1.Contains("Buy cheap Shoes, Sneekers and Heels!"));
			writer.Dispose();
		}
		private void Test(IndexSearcher searcher, string query)
		{
			var result = Search(searcher, query);
			Console.WriteLine(string.Join("\n", result));
			Assert.AreEqual(1, result.Count);
		}
		private List<string> Search(IndexSearcher searcher, string expr)
		{
			var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
			var queryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "shopping", analyzer);
			var query = queryParser.Parse(expr);
			return Search(searcher, query);
		}
		private List<string> Search(IndexSearcher searcher, Query query)
		{
			var collector = TopScoreDocCollector.Create(1000, true);
			searcher.Search(query, collector);
			var result = new List<string>();
			var matches = collector.TopDocs().ScoreDocs;
			foreach (var item in matches)
			{
				var id = item.Doc;
				var doc = searcher.Doc(id);
				result.Add(doc.GetField("shopping").StringValue);
			}
			return result;
		}
		IndexWriter CreateIndex()
		{
			var directory = new RAMDirectory();
			var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
			var writer = new IndexWriter(directory, analyzer, new IndexWriter.MaxFieldLength(1000));
			return writer;
		}
		void Add(IndexWriter writer, string text)
		{
			var document = new Document();
			document.Add(new Field("shopping", text, Field.Store.YES, Field.Index.ANALYZED));
			writer.AddDocument(document);
		}
	}
