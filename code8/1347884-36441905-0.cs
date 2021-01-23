    private XmlWriterSettings fragmentSettings = new XmlWriterSettings
        {
            ConformanceLevel = ConformanceLevel.Auto,
            Encoding = Encoding.UTF8
        };
     public override void Output(IRow input, IUnstructuredWriter output)
        {
            IColumn badColumn = input.Schema.FirstOrDefault(col => col.Type != typeof(string));
            if (badColumn != null)
            {
                throw new ArgumentException(string.Format("Column '{0}' must be of type 'string', not '{1}'", badColumn.Name, badColumn.Type.Name));
            }
            using (var writer = XmlWriter.Create(output.BaseStream, this.fragmentSettings))
            {
                writer.WriteStartElement(this.rowPath);
                foreach (IColumn col in input.Schema)
                {
                    var value = input.Get<string>(col.Name);
                    if (value != null)
                    {
                        // Skip null values in order to distinguish them from empty strings
                        writer.WriteElementString(this.columnPaths[col.Name] ?? col.Name, value);
                    }
                }
                writer.WriteEndElement(); //explicit closing tag for stream
            }
        }
