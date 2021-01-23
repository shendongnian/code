        public static WindsorContainer _WindsorContainer { get; set; }
        protected void Application_Start()
        {
            InitiateSolr();
        }
        protected void Application_End()
        {
            _WindsorContainer.Dispose();
        }
        /// <summary>
        /// Initialized Misc Solr Indexes
        /// </summary>
        protected void InitiateSolr() {
            var reader = ApplicationConfig.GetResourceReader("~/Settings/AppSettings.resx");
            InitiateSolrFacetedIndex(reader);
        }
        /// <summary>
        /// Initializes The Faceted Search Indexes
        /// </summary>
        protected void InitiateSolrFacetedIndex(ResourceReader reader) {
            Data d = new Data();
            _WindsorContainer = new WindsorContainer();
            
            var solrFacility = new SolrNetFacility(reader.ResourceCollection["Url.SolrIndexPath"] + "EN");
            foreach (var item in d.GetLanguages())
            {
                solrFacility.AddCore("ProductSpecIndex" + item.LanguageCode.ToString(), typeof(Dictionary<string, object>), reader.ResourceCollection["Url.SolrIndexPath"] + item.LanguageCode.ToString());
            }
            _WindsorContainer.AddFacility("solr", solrFacility);
            Models.Solr.SolrWindsorContainer c = new Models.Solr.SolrWindsorContainer();
            c.SetContainer(_WindsorContainer);
        }
