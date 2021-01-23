	public override string ToString()
	{
		StringBuilder content = new StringBuilder();
		foreach (var prop in this.GetType().GetProperties())
		{
			var propertyType = prop.PropertyType;
			var propertyValue = prop.GetValue(this);
			if (propertyValue != null)
			{
				if (propertyValue is IEnumerable<string>)
					content.AppendFormat("{0} = {1}", prop.Name, PrintList(propertyValue as IEnumerable<string>));
				else
					content.AppendFormat("{0} = {1}", prop.Name, propertyValue.ToString());
			}
			else
				content.AppendFormat("{0} = null", prop.Name);
			content.AppendLine();
		}
		return content.ToString();
	}
	private string PrintList(IEnumerable<string> list)
	{
		var content = string.Join(",", list.Select(i => string.Format("[{0}]", i)));
		return content;
	}
