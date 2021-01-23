	public class JsonMediaFormatter : MediaTypeFormatter
	{
		private readonly JsonSerializer _jsonSerializer = new JsonSerializer();
		public JsonMediaFormatter()
		{
			SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
		}
		public override Boolean CanReadType(Type type)
		{
			if (type == null)
				return false;
			return true;
		}
		public override Boolean CanWriteType(Type type)
		{
			if (type == null)
				return false;
			return true;
		}
		public override Task<Object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
		{
			return Task.Factory.StartNew(() => Deserialize(readStream, type));
		}
		public override Task WriteToStreamAsync(Type type, Object value, Stream writeStream, HttpContent content, TransportContext transportContext, CancellationToken cancellationToken)
		{
			return Task.Factory.StartNew(() => Serialize(writeStream, value));
		}
		private Object Deserialize(Stream readStream, Type type)
		{
			var streamReader = new StreamReader(readStream);
			return _jsonSerializer.Deserialize(streamReader, type);
		}
		private void Serialize(Stream writeStream, Object value)
		{
			var streamWriter = new StreamWriter(writeStream);
			_jsonSerializer.Serialize(streamWriter, value);
			streamWriter.Flush();
		}
	}
