    // to hold sets of neighbour nodes
    Dictionary<int, List<Node>> relatedCollectionsDictionary = new Dictionary<int, List<Node>>();
    int index = 0;
    List<Node> nList;
    while (nList.Any())
    {
        var relatedCollection = nList.Where(n => (Math.Sqrt(Math.Pow((n.x - nList.First().x), 2) + Math.Pow((n.y - nList.First().y), 2) + Math.Pow((n.z - nList.First().z), 2)) <= gap));
        List<Node> relatedCollectionList = relatedCollection.ToList();
        List<Node> relatedCollectionListForDictionary = relatedCollection.ToList();
        relatedCollectionsDictionary.Add(index++, relatedCollectionListForDictionary);
        while (relatedCollectionList.Any())
        {
            nList.Remove(relatedCollectionList.First());
            relatedCollectionList.RemoveAt(0);
        }
    }
