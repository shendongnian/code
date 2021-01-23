        List<string> strings = new List<string>
        {
            "https://linkedin.com/in/username",
            "https://www.facebook.com/username",
            "username",
            "https://plus.google.com/u/0/username/"
        };
        List<Tuple<int, string>> results = new List<Tuple<int, string>>();
        for (int i = 0; i < strings.Count; i++)
        {
            var s = strings.ElementAt(i);
            try
            {
                Uri uri = new Uri(s);
                var lastSegment = uri.Segments.LastOrDefault();
                if (!lastSegment.EndsWith("/") && !string.IsNullOrEmpty(lastSegment))
                    results.Add(new Tuple<int, string>(i, lastSegment));
            }
            catch (Exception ex)
            {
                //s is not a valid uri and thus a valid uri object could not be created out of it
                results.Add(new Tuple<int, string>(i, ex.Message));
            }
        }
        foreach (var segment in results)
            Console.WriteLine(segment);
