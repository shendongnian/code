    public void UpdateDocumentBatch(Term keyTerm, IEnumerable<Document> documents, string indexName)
    {
    	using (var analyser = new StandardAnalyzer(LuceneVersion))
    	{
    		using (var directory = new AzureDirectory(cloudStorage.GetStorageAccount(), indexName, new RAMDirectory()))
    		{
    			var createIndex = !IndexReader.IndexExists(directory);
    
    			using (var indexWriter = new IndexWriter(directory, analyser, createIndex, IndexWriter.MaxFieldLength.UNLIMITED))
    			{
    				indexWriter.SetRAMBufferSizeMB(100);
    
    				foreach (var document in documents)
    				{
    					keyTerm.Text = document.GetField(keyTerm.Field).StringValue;
    					indexWriter.UpdateDocument(keyTerm, document);
    				}
    
    				indexWriter.Commit();
    			}
    		}
    	}
    }
