    public static class JsonExtensions
    {
        public static void RemoveFromLowestPossibleParent(this JToken node)
        {
            if (node == null)
                throw new ArgumentNullException();
            var contained = node.AncestorsAndSelf().Where(t => t.Parent is JArray || t.Parent is JObject).FirstOrDefault();
            if (contained != null)
                contained.Remove();
        }
        public static void MoveTo(this JToken token, JObject newParent)
        {
            if (newParent == null)
                throw new ArgumentNullException();
            var toMove = token.AncestorsAndSelf().OfType<JProperty>().First(); // Throws an exception if no parent property found.
            toMove.Remove();
            newParent.Add(toMove);
        }
    }
