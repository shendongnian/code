    [IndexField("_uniqueid")]
        public override IIndexableUniqueId UniqueId
        {
          get
          {
            return new IndexableUniqueId<string>("uniqueidvalue");
          }
        }
