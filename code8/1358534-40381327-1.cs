	using (var w = new ResourceWriter(resources))
	{
		using (var r = new ResXResourceReader(resx))
		{
			r.BasePath = Path.GetDirectoryName(resx);
			var e = r.GetEnumerator();
			while (e.MoveNext())
			{
				item = (DictionaryEntry)e.Current;
				w.AddResource(item.Key as string, item.Value);
			}
		}
	}
