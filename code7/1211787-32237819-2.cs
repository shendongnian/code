		using (JsonTextReader reader = new JsonTextReader(new StringReader(json)))
		{
			reader.SupportMultipleContent = true;
		
			var serializer = new JsonSerializer();
			while (reader.Read())
			{
				List<Contact> contacts = serializer.Deserialize<List<Contact>>(reader);
				foreach (Contact c in contacts)
				{
					Console.WriteLine(c.FirstName + " " + c.LastName);
				}
			}
		}
