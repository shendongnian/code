    private static SolrQueryResults<SolrConsistencyCheckDocument> FindAllDocumentsWithDebugEnabled(string searchQuery, QueryOptions qo)
    {
            var directConnection = ServiceLocator.Current.GetInstance<ISolrConnection>();
            var queryResult = new SolrQueryResults<SolrConsistencyCheckDocument>();
            var debugParams = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("debugQuery", "true") };
            qo.ExtraParams = debugParams;
            var parser = ServiceLocator.Current.GetInstance<ISolrAbstractResponseParser<SolrConsistencyCheckDocument>>();
            var solrQueryTest = new SolrQueryExecuter<SolrConsistencyCheckDocument>(
                parser,
                directConnection,
                ServiceLocator.Current.GetInstance<ISolrQuerySerializer>(),
                ServiceLocator.Current.GetInstance<ISolrFacetQuerySerializer>(),
                ServiceLocator.Current.GetInstance<ISolrMoreLikeThisHandlerQueryResultsParser<SolrConsistencyCheckDocument>>());
            var parameters = solrQueryTest.GetAllParameters(new SolrQuery(searchQuery), qo);
            var resultq = directConnection.Get(solrQueryTest.Handler, parameters);
            var responseXML = XDocument.Parse(resultq);
            LogDebugElement(responseXML);
            parser.Parse(responseXML, queryResult);
            return queryResult;
        }
