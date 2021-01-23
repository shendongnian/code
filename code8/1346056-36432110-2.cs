    private Event nvcToCoreEvent(NameValueCollection nvc)
    {
	    Func<string, string> getBinderKey = delegate (string originalKey)
	    {
		    IList<string> keyParts = new List<string>();
            // Capture anything between square brackets.
		    foreach (Match m in Regex.Matches(originalKey, @"(?<=\[)(.*?)(?=\])"))
		    {
			    int collectionIndex;
			    if (int.TryParse(m.Value, out collectionIndex))
			    {
                    // Preserve what should be actual indexer calls.
				    keyParts[keyParts.Count - 1] += "[" + m.Value + "]";
			    }
			    else
			    {
				    keyParts.Add(m.Value);
			    }
		    }
            // Format the key the way the default binder expects it.
		    return string.Join(".", keyParts);
	    };
        // Convert the NameValueCollection to a FormDataCollection so we use it's magic sauce.
	    FormDataCollection formData = new FormDataCollection(nvc.AllKeys.Select(x => new KeyValuePair<string, string>(getBinderKey(x), nvc[x])));
        // Internally this actually uses a model binder to do the mapping work!
	    return formData.ReadAs<Event>();
    }
