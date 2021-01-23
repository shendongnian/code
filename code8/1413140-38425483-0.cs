        static IEnumerable<string> ReadNames(XmlReader reader)
        {
            while (reader.ReadToFollowing("InformationTuple"))
            {
                using (var subReader = reader.ReadSubtree())
                {
                    subReader.ReadToFollowing("Name");
                    var name = subReader.ReadElementContentAsString();
                    yield return name;
                }
            }
        }
