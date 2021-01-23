        static IEnumerable<string> ReadNestedNames(XmlReader reader)
        {
            foreach (var subReader in reader.ReadSubtrees("InformationTuples").SelectMany(r => r.ReadSubtrees("InformationTuple")))
            {
                subReader.ReadToFollowing("Name");
                var name = subReader.ReadElementContentAsString();
                yield return name;
            }
        }
