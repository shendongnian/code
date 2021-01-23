    public class Nasa
    {
        public string copyright { get; set; }
        public string date { get; set; }
        public string explanation { get; set; }
        public string hdurl { get; set; }
        public string media_type { get; set; }
        public string service_version { get; set; }
        public string title { get; set; }
        public string url { get; set; }
    }
    
    public interface ITransformFetch<in T>
    {
        void Transform(T data);
    }
    
    public interface IFetch<out T> 
    {
        T Fetch();
    }
    
    public class NasaFetcher : IFetch<Nasa>
    {
        private const string NasaUrl = "https://api.nasa.gov/planetary/apod?api_key=NNKOjkoul8n1CH18TWA9gwngW1s1SmjESPjNoUFo";
    
        private readonly IHttpClientWrapper _client;
    
        public NasaFetcher(IHttpClientWrapper client)
        {
            _clientFactory = client;
        }
    
        public Nasa Fetch()
        {
            var response = _client.GetAsync(NasaUrl).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Nasa>(data);
        }
    }
    
    public class NasaFetchImageTransformer : ITransformFetch<Nasa>
    {
        public void Transform(Nasa data)
        {
            // transform data
        }
    }
    
    public class NasaFetchVideoTransformer : ITransformFetch<Nasa>
    {
        public void Transform(Nasa data)
        {
            // transform data
        }
    }
        
    public class NasaFetcherTransformerDecorator : IFetch<Nasa>
    {
        private readonly IFetch<Nasa> _fetcher;
    
        public NasaFetcherTransformerDecorator(IFetch<Nasa> fetcher)
        {
            _fetcher = fetcher;
        }
    
        public Nasa Fetch()
        {
            var result = _fetcher.Fetch();
            if (result != null)
            {
                switch (result.media_type)
                {
                    case "image":
                        var nasaFetchImageTransformer = new NasaFetchImageTransformer();
                        nasaFetchImageTransformer.Transform(result);
                        break;
    
                    case "video":
                        var nasaFetchVideoTransformer = new NasaFetchVideoTransformer();
                        nasaFetchVideoTransformer.Transform(result);
                        break;
                }
            }
    
            return result;
        }
    }
    
    public class Test
    {
        public void TestNasaFetcher()
        {
            var data = new NasaFetcherTransformerDecorator(new NasaFetcher(new HttpClientWrapper()));
            var nasa = data.Fetch();
        }
    }
