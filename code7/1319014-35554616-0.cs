    public class SolrAuth : IHttpWebRequestFactory
    {
    	public IHttpWebRequest Create(Uri url)
    	{
    		//... credentials, timeouts, etc.
    		return new HttpWebRequestAdapter((HttpWebRequest)webrequest);
    	}
    }
    public class SolrMachine<T> : ISolrMachine<T> where T : ISolrRecord
    {
    	public WindsorContainer myContainer = new WindsorContainer();
    	private ISolrOperations<T> actuallyInstance { get; set; }
    	public SolrMachine(string coreName)
    	{
    		var url = string.Format("http://xxx/solr/{0}", coreName);
    		myContainer.Register(Component.For<IHttpWebRequestFactory>().ImplementedBy<SolrAuth>());
    		var solrFacility = new SolrNetFacility(string.Format("http://xxx/solr/{0}", "defaultCollection"));
    		solrFacility.AddCore(coreName, typeof(T), url);
    		myContainer.AddFacility(solrFacility);
    		this.actuallyInstance = myContainer.Resolve<ISolrOperations<T>>();
    	}
    }
