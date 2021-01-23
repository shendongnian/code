    public List<string> GetServiceModelProprty(string EntityName, bool ShowGeneric = false)
        {
            List<string> ProNames = new List<string>();
            var names = Type.GetType(EntityName)
                .GetProperties()
                .Select(p => p.Name).ToArray();
            ProNames.AddRange(names);
            return ProNames;
        }
