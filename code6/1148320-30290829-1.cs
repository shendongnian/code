	JSchema schema = new JSchema
	{
		Type = JSchemaType.Object,
		Properties =
		{
			{ "name", new JSchema { Type = JSchemaType.String } },
			{
				"hobbies", new JSchema
				{
					Type = JSchemaType.Array,
					Items = { new JSchema { Type = JSchemaType.String } }
				}
			},
		}
	};
	string schemaJson = schema.ToString();
	Console.WriteLine(schemaJson);
	// {
	//   "type": "object",
	//   "properties": {
	//     "name": {
	//       "type": "string"
	//     },
	//     "hobbies": {
	//       "type": "array",
	//       "items": {
	//         "type": "string"
	//       }
	//     }
	//   }
	// }
	JObject person = JObject.Parse(@"{
	  'name': 'James',
	  'hobbies': ['.NET', 'Blogging', 'Reading', 'Xbox', 'LOLCATS']
	}");
	bool valid = person.IsValid(schema);
	Console.WriteLine(valid);
	// true
