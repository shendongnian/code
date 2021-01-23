	public class EntityConverter : JsonConverter<Entity>
	{
		public override void WriteJson( JsonWriter writer, Entity value, JsonSerializer serializer )
		{
			var me = new JObject();
			me["$id"] = new JValue( serializer.ReferenceResolver.GetReference( serializer, value ) );
			me["your_array"] = JArray.FromObject( value.components, serializer );
			me["your_other_values"] = new JValue( value.tag );
			me.WriteTo( writer );
		}
		public override Entity ReadJson( JsonReader reader, Type objectType, Entity existingValue, bool hasExistingValue, JsonSerializer serializer )
		{
			var o = JObject.Load( reader );
			var id = (string)o["$id"];
			if( id != null )
			{
				var entity = new Entity();
				serializer.Populate( o.CreateReader(), entity );
				return entity;
			}
			else
			{
				var reference = (string)o["$ref"];
				return serializer.ReferenceResolver.ResolveReference( serializer, reference ) as Entity;
			}
		}
	}
