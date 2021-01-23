    [TestClass]
	public class UnitTest4
	{
		[TestMethod]
		public void TestLucene()
		{
			var writer = CreateIndex();
			Add(writer, "tasty", "00018389732061");
			writer.Flush(true, true, true);
			var searcher = new IndexSearcher(writer.GetReader());
			Test(searcher, "(Description:tasty) (Gtin:00018389732061)");
			Test(searcher, "Description:tasty Gtin:00018389732061");
			Test(searcher, "+Description:tasty +Gtin:00018389732061");
			Test(searcher, "+Description:tasty +Gtin:000*");
			writer.Dispose();
		}
		private void Test(IndexSearcher searcher, string query)
		{
			var result = Search(searcher, query);
			Console.WriteLine(string.Join(", ", result));
			Assert.AreEqual(1, result.Count);
			Assert.AreEqual("00018389732061", result[0]);
		}
		private List<string> Search(IndexSearcher searcher, string expr)
		{
			using (var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
			{
				var queryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "Description", analyzer);
				var collector = TopScoreDocCollector.Create(1000, true);
				var query = queryParser.Parse(expr);
				searcher.Search(query, collector);
				var result = new List<string>();
				var matches = collector.TopDocs().ScoreDocs;
				foreach (var item in matches)
				{
					var id = item.Doc;
					var doc = searcher.Doc(id);
					result.Add(doc.GetField("Gtin").StringValue);
				}
				return result;
			}
		}
		IndexWriter CreateIndex()
		{
			var directory = new RAMDirectory();
			var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
			var writer = new IndexWriter(directory, analyzer, new IndexWriter.MaxFieldLength(1000));
			return writer;
		}
		void Add(IndexWriter writer, string desc, string id)
		{
			var document = new Document();
			document.Add(new Field("Description", desc, Field.Store.YES, Field.Index.ANALYZED));
			document.Add(new Field("Gtin", id, Field.Store.YES, Field.Index.NOT_ANALYZED));
			writer.AddDocument(document);
		}
	}
