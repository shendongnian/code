    using (TextWriter writer = new StreamWriter(filename, false, Encoding.UTF8))
	{
		using (XmlWriter wr = XmlWriter.Create(writer, **ws**))
		{
			// Namespace?
			XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
			ns.Add("", "");
			serializer.Serialize(wr, o, ns);
		}
		writer.Close();
	}
