    public class NodeConverter : JsonConverter
    {
        public override bool CanRead { get { return true; } }
    
        public override bool CanWrite { get { return false; } }
    
        public override bool CanConvert( Type objectType ) { return typeof( Node ).IsAssignableFrom( objectType ); }
    
    
        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            throw new NotImplementedException("If CanWrite is false; this won't be called.");
        }
    
    
        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            var jToken = JToken.ReadFrom( reader );
    
            var refString = jToken.Value< string >( "$ref" );
            var firstReference = refString == null;
    
            if ( firstReference )
            {
                var typeString = jToken.Value<string>( "$type" );
    
                if ( typeString != null )
                {
                    var type = Type.GetType( typeString );
    
                    if ( type == null )
                    {
                        var errorNode = new ErrorNode();
                        
                        errorNode.JToken = jToken;
                        errorNode.FailedTypeString = typeString;
    
                        // Apply the old node's relationships to errorNode
                        serializer.Populate( jToken.CreateReader(), errorNode );
    
                        return errorNode;
                    }
                }
            }
    
            // Default-like behaviour
            return serializer.Deserialize( jToken.CreateReader() );
        }
    }
