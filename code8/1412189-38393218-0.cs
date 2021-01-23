    [Serializable]
    public Places : Facet, IPlaces
    {
        private const string FIELD_PLACES = "Places";
        
        public Places()
        {
           this.EnsureDictionary<IPlace>(FIELD_PLACES);
        }
    
       
        public IElementDictionary<IPlace> Places 
        { 
          get
          {
              return this.GetCollection<IPlace>(FIELD_PLACES);
          }
    
        }
    }
