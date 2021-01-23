            var unwanteds = new HashSet<string>(new[] 
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
            foreach (var property in obj.SelectTokens("[*]").SelectMany(o => o.OfType<JProperty>()).Where(p => unwanteds.Contains(p.Name)).ToList())
            {
                property.Remove();
            }
