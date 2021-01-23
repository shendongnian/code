    private static string GetCollectionItemIndex(string collectionIndexFieldName)
    {
        Queue<string> previousIndices = (Queue<string>) HttpContext.Current.Items[collectionIndexFieldName];
        if (previousIndices == null) {
            HttpContext.Current.Items[collectionIndexFieldName] = previousIndices = new Queue<string>();
    
            string previousIndicesValues = HttpContext.Current.Request[collectionIndexFieldName];
            if (!String.IsNullOrWhiteSpace(previousIndicesValues)) {
                foreach (string index in previousIndicesValues.Split(','))
                    previousIndices.Enqueue(index);
            }
        }
    
        return previousIndices.Count > 0 ? previousIndices.Dequeue() : Guid.NewGuid().ToString();
    }
