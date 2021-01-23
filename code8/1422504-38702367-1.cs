    var originalCollection = [ 2, 5, 7, 8, 0, 0, 0 ].ToList();
    int removeCount = 0;
    while (originalCollection[originalCollection.Count - 1] == 0) {
        removeCount++;
    }
    originalCollection.RemoveRange( (originalCollection - removeCount - 1), (originalCollection - 1) );
    var finalElement = originalCollection[originalCollection.Count - 1];
    for (int i = removeCount; i > 0; i--) {
        originalCollection.Add(finalElement)
    }
