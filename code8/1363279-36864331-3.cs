    public LazyProductlistdata
    {
        public string id { get; set; }
        private Lazy<Productlistdata> data = new Lazy<Productlistdata>(()=>new Productlistdata(id));
        public Productlistdata Data
        {
           get{return data.Value;}
        }
    }
