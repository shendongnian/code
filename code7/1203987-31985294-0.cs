			var property = modelObject.GetType().GetProperty("Keyword");
			var propValue = property.GetValue(modelObject);
			foreach (var s in Enum.GetNames(property.PropertyType))
				Console.WriteLine(s);
			Console.WriteLine(propValue.ToString());
