    var categories = new Dictionary<String, Category>(StringComparer.InvariantCultureIgnoreCase);
    using (var reader = new StringReader(_SampleData))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            if (String.IsNullOrWhiteSpace(line))
                continue;
            var elements = line.Split('-');
            var id = int.Parse(elements[0]);
            var name = elements[1].Trim();
            var index = name.LastIndexOf('>');
            Category parent = null;
            if (index >= 0)
            {
                var parentName = name.Substring(0, index).Trim();
                categories.TryGetValue(parentName, out parent);
            }
            var category = new Category(id, name, parent);
            categories.Add(category.Name, category);
        }
    }
