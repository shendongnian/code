        public MainViewModel()
        {
            mapData = new SqlGeometryToShapeConverter();
        }
        private SqlGeometryToShapeConverter mapData;
        public SqlGeometryToShapeConverter MapData
        {
            get
            {
                return mapData;
            }
            set
            {
                Set(() => MapData, ref mapData, value);
            }
        }
