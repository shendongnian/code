    public interface IDocument
    {
        int Id { get; }
    }
    public class DocConverter
    {
        private readonly Dictionary<string, Func<MetaInformation, object>> deserializers = new Dictionary<string, Func<MetaInformation, object>>();
        private readonly Dictionary<Type, Func<object, string>> serializers = new Dictionary<Type, Func<object, string>>();
        private class MetaInformation
        {
            [Newtonsoft.Json.JsonProperty( "id" )]
            public int Id { get; set; }
            [Newtonsoft.Json.JsonProperty( "type" )]
            public string Type { get; set; }
            [Newtonsoft.Json.JsonProperty( "_source" )]
            public object Source { get; set; }
        }
        public void Register<Source, SourceData>( string contractName, Func<Source, SourceData> converter, Func<int, SourceData, Source> reverter )
            where Source : class, IDocument
            where SourceData : class
        {
            deserializers.Add( contractName,
                ( m ) =>
                {
                    SourceData data = Newtonsoft.Json.JsonConvert.DeserializeObject<SourceData>( m.Source.ToString() );
                    return reverter( m.Id, data );                    
                } );
            serializers.Add( typeof( Source ),
                ( o ) =>
                {
                    var meta = new MetaInformation { Id = ( o as IDocument ).Id, Type = contractName, Source = converter( (Source) o ), };
                    return Newtonsoft.Json.JsonConvert.SerializeObject( meta );
                } );
        }
        public string Serialize( object source )
        {
            return serializers[ source.GetType() ]( source );
        }
        public object Deserialize( string jsonData )
        {
            var meta = Newtonsoft.Json.JsonConvert.DeserializeObject<MetaInformation>( jsonData );
            return deserializers[ meta.Type ]( meta );
        }
    }
