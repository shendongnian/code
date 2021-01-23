    private Event nvcToCoreEvent(NameValueCollection nvc)
    {
	    Func<string, string> getBinderKey = delegate (string originalKey)
	    {
		    IList<string> keyParts = new List<string>();
		    foreach (Match m in Regex.Matches(originalKey, @"(?<=\[)(.*?)(?=\])"))
		    {
			    int collectionIndex;
			    if (int.TryParse(m.Value, out collectionIndex))
			    {
				    keyParts[keyParts.Count - 1] += "[" + m.Value + "]";
			    }
			    else
			    {
				    keyParts.Add(m.Value);
			    }
		    }
		    return string.Join(".", keyParts);
	    };
	    FormDataCollection formData = new FormDataCollection(nvc.AllKeys.Select(x => new KeyValuePair<string, string>(getBinderKey(x), nvc[x])));
	    return formData.ReadAs<Event>();
    }
