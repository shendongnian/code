            var keepers = new HashSet<string>(new[]
            {
                "reviewerID",
                "asin",
                "reviewerName",
                "reviewText",
                "overall",
                "summary",
                "unixReviewTime",
                "reviewTime",
            });
            foreach (var property in obj.Children().SelectMany(o => o.OfType<JProperty>()).Where(p => !keepers.Contains(p.Name)).ToList())
            {
                property.Remove();
            }
