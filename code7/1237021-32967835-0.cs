            var obj = JObject.Parse(json);
            // Collect column titles: all property names whose values are of type JValue, distinct, in order of encountering them.
            var values = obj.DescendantsAndSelf()
                .OfType<JProperty>()
                .Where(p => p.Value is JValue)
                .GroupBy(p => p.Name)
                .ToList();
            var columns = values.Select(g => g.Key).ToArray();
            // Filter JObjects that have child objects that have values.
            var parentsWithChildren = values.SelectMany(g => g).SelectMany(v => v.AncestorsAndSelf().OfType<JObject>().Skip(1)).ToHashSet();
            // Collect all data rows: for every object, go through the column titles and get the value of that property in the closest ancestor or self that has a value of that name.
            var rows = obj
                .DescendantsAndSelf()
                .OfType<JObject>()
                .Where(o => o.PropertyValues().OfType<JValue>().Any())
                .Where(o => o == obj || !parentsWithChildren.Contains(o)) // Show a row for the root object + objects that have no children.
                .Select(o => columns.Select(c => o.AncestorsAndSelf()
                    .OfType<JObject>()
                    .Select(parent => parent[c])
                    .Where(v => v is JValue)
                    .Select(v => (string)v)
                    .FirstOrDefault())
                    .Reverse() // Trim trailing nulls
                    .SkipWhile(s => s == null)
                    .Reverse());
            // Convert to CSV
            var csvRows = new[] { columns }.Concat(rows).Select(r => string.Join(",", r));
            var csv = string.Join("\n", csvRows);
            Console.WriteLine(csv);
