    Microsoft provides a way to do this via `HtmlHelper.AnonymousObjectToHtmlAttributes`, but so you don't need a dependency on the `System.Web.Mvc` namespace, the source for that method is as follows:
		public static IDictionary<string, object> AnonymousObjectToHtmlAttributes(object htmlAttributes)
		{
			Dictionary<string, object> result;
			var valuesAsDictionary = htmlAttributes as IDictionary<string, object>;
			if (valuesAsDictionary != null)
			{
				result = new Dictionary<string, object>(valuesAsDictionary, StringComparer.OrdinalIgnoreCase);
			}
			else
			{
				result = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
		
				if (htmlAttributes != null)
				{
					foreach (var prop in htmlAttributes.GetType().GetRuntimeProperties())
					{
						var value = prop.GetValue(htmlAttributes);
						result.Add(prop.Name, value);
					}
				}
			}
		
			return result;
        }
    That should give you the inspiration you need to adapt it for your own code.
