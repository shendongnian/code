	public class GroupYamlConverter : IYamlTypeConverter
	{
		private readonly Deserializer deserializer;
		
		public GroupYamlConverter(Deserializer deserializer)
		{
			this.deserializer = deserializer;
		}
		
		public bool Accepts(Type type)
		{
			return type == typeof(Group);
		}
		public object ReadYaml(IParser parser, Type type)
		{
			var group = new Group();
			
			var reader = new EventReader(parser);
			do
			{
				var key = reader.Expect<Scalar>();
				if(key.Value == "Name")
				{
					group.Name = reader.Expect<Scalar>().Value;
				}
				else
				{
					group.ColumnNames = key.Value
						.Split(',')
						.Select(n => n.Trim())
						.ToArray();
					
					group.Rows = deserializer.Deserialize<IList<IList<object>>>(reader);
				}
			} while(!reader.Accept<MappingEnd>());
			reader.Expect<MappingEnd>();
			
			return group;
		}
		public void WriteYaml(IEmitter emitter, object value, Type type)
		{
			throw new NotImplementedException("TODO");
		}
	}
