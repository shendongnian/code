    [TestClass]
	public class UnitTest3
	{
		[TestMethod]
		public void TestLucene()
		{
			var writer = CreateIndex();
			AddDish(writer, "chicken soup", "1");
			AddDish(writer, "veg soup", "2");
			AddDish(writer, "chicken balti", "3");
			writer.Flush(true, true, true);
			Assert.AreEqual(3, writer.NumDocs());
			var searcher = new IndexSearcher(writer.GetReader());
			Search(searcher, "chicken AND soup");
			Search(searcher, "\"chicken\" AND \"soup\"");
			Search(searcher, "+chicken +soup");
			writer.Dispose();
		}
		private void Search(IndexSearcher searcher, string query)
		{
			var result = SearchDishName(searcher, query);
			Console.WriteLine(string.Join(", ", result));
			Assert.AreEqual(1, result.Count);
			Assert.AreEqual("1", result[0]);
		}
		private List<string> SearchDishName(IndexSearcher searcher, string textSearch)
		{
			using (var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30))
			{
				var queryParser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "DishName", analyzer);
				var collector = TopScoreDocCollector.Create(1000, true);
				var query = queryParser.Parse(textSearch);
				searcher.Search(query, collector);
				var result = new List<string>();
				var matches = collector.TopDocs().ScoreDocs;
				foreach (var item in matches)
				{
					var id = item.Doc;
					var doc = searcher.Doc(id);
					result.Add(doc.GetField("CustomisationID").StringValue);
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
		void AddDish(IndexWriter writer, string dishname, string id)
		{
			var document = new Document();
			document.Add(new Field("DishName", dishname, Field.Store.YES, Field.Index.ANALYZED));
			document.Add(new Field("CustomisationID", id, Field.Store.YES, Field.Index.NOT_ANALYZED));
			writer.AddDocument(document);
		}
	}
