    public static class JsonExtensions
    {
        public static JToken MatchToken(this JToken target, JToken source)
        {
            var sourceArray = source.Parent as JArray;
            if (sourceArray != null)
            {
                var targetArray = target.SelectToken(sourceArray.Path) as JArray;
                if (targetArray != null)
                {
                    // There may be duplicated values in the source and target arrays. If so, get the relative index of the
                    // incoming value in the list of duplicates in the source, and return the corresponding value in the list
                    // of duplicates in the target.
                    var sourceIndices = Enumerable.Range(0, sourceArray.Count).Where(i => JToken.DeepEquals(sourceArray[i], source)).ToList();
                    var targetIndices = Enumerable.Range(0, targetArray.Count).Where(i => JToken.DeepEquals(targetArray[i], source)).ToList();
                    var matchIndex = sourceIndices.IndexOf(sourceArray.IndexOf(source));
                    Debug.Assert(matchIndex >= 0);// Should be found inside its parent.
                    if (matchIndex >= 0 && matchIndex < targetIndices.Count)
                        return targetArray[targetIndices[matchIndex]];
                    return null;
                }
            }
            return target.SelectToken(source.Path);
        }
    }
