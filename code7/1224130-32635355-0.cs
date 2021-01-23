	  public class IndexOperations<T> where T:Topic
		{
		  public ElasticConnector ElasticConnector { get; set; }
		  public IndexOperations(ElasticConnector elasticConnector)
			{
				ElasticConnector = elasticConnector;
			}
		  public IBulkResponse CreateMany(IEnumerable<T> t)
			{
				return ElasticConnector.Client.Bulk(b => b.CreateMany(t));
			}
		}
