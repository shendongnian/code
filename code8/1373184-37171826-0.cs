        while (match.Success)
        {
            //results.Add(input);
            foreach (var name in groupNames)
            {
                if (match.Groups[name].Captures.Count > 0) results.Add(match.Groups[name].Value);
                else results.Add(String.Empty);
            }
            match = match.NextMatch();
        }
        return results.Count > 0 ? results.ToArray() : null;
