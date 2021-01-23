        private static IEnumerable<PortableExecutableReference> GetMetadataReferencesToCopy(string path, IEnumerable<MetadataReference> metadataReferences)
        {
            var references = metadataReferences
                .OfType<PortableExecutableReference>()
                .Select(x => new
                {
                    Name = Path.GetFileNameWithoutExtension(x.FilePath),
                    Reference = x,
                })
                .ToDictionary(x => x.Name, x => x.Reference);
            var xmldoc = new XmlDocument();
            xmldoc.Load(path);
            foreach (XmlNode item in xmldoc.GetElementsByTagName("Reference"))
            {
                var include = item.Attributes?
                   .OfType<XmlAttribute>()
                   .FirstOrDefault(x => x.Name == "Include")?
                   .Value;
                if (include == null)
                {
                    continue;
                }
                var name = new AssemblyName(include).Name;
                bool copyLocal;
                if (bool.TryParse(item.ChildNodes?
                       .OfType<XmlNode>()
                       .FirstOrDefault(x => x.Name == "Private")?
                       .InnerText, out copyLocal) &&
                    references.ContainsKey(name) &&
                    copyLocal)
                {
                    yield return references[name];
                }
            }
        }
