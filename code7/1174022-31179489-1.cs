	IList<KeyValuePair<string, string>> tagAttributes;
	StringBuilder parsedText = new StringBuilder();
	char character;
	for (int index = 0, length = htmlContent.Length; index < length; index++)
	{
		character = htmlContent[index];
		if (character == '<')
		{
			Match tagMatch = tagRegex.Match(htmlContent, index);
			// prevent parsing of invalid HTML with incomplete tags like <tabl<p>This is a paragraph</p>
			if (tagMatch.Index != index)
			{
				parsedText.Append("&lt;");
				continue;
			}
			if (tagMatch.Groups["attribute"].Success)
			{
				tagAttributes = new List<KeyValuePair<string, string>>();
				// attribute count and their type counts (valued or state only) match
				var attributes = tagMatch
					.Groups["name"]
					.Captures
					.Cast<Capture>()
					.Select(c => c.Value)
					.Zip(
						tagMatch
							.Groups["hasvalue"]
							.Captures
							.Cast<Capture>()
							.Select(c => c.Value == "="),
						(name, isvalued) => new KeyValuePair<string, bool>(name, isvalued)
					);
				// attribute values count may be less than there are attributes
				IEnumerator<string> values = tagMatch
					.Groups["value"]
					.Captures
					.Cast<Capture>()
					.Select(c => c.Value)
					.GetEnumerator();
				foreach (var attribute in attributes)
				{
					tagAttributes.Add(
						new KeyValuePair<string, string>(
							attribute.Key,
							attribute.Value && values.MoveNext() ?
								values.Current :
								null)
					);
				}
			}
			/* Do whatever you need with these
			 *
			 * TAG NAME <= tagMatch.Groups["tag"].Value;
			 * IS CLOSING <= tagMatch.Groups["isclosing"].Success;
			 * IS SELF CLOSING <= tagMatch.Groups["selfclosing"].Success;
			 * ATTRIBUTES LIST <= tagAttributes
			 */
			// advance content character index past currently regex matched tag definition
			index += tagMatch.Length - 1;
		}
		else
		{
			parsedText.Append(character);
		}
	}
