	Root obj = JsonConvert.DeserializeObject<Root>(
		json, new JsonSerializerSettings
		{
			Error = (sender, args) =>
			{
				Reading reading = args.CurrentObject as Reading;
				
				if (reading != null && args.ErrorContext.Member.ToString() == "temperature")
				{
					reading.Temperature = null;
					args.ErrorContext.Handled = true;
				}
			}
		});
