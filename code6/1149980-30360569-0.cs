    foreach (var bookmark in wordDoc.Range.Bookmarks.Cast<Aspose.Words.Bookmark>())
    {
        Console.WriteLine(bookmark.Name);
        // Get all the nodes between bookmark start and end
        ArrayList extractedNodes = ExtractContent(bookmark.BookmarkStart, bookmark.BookmarkEnd, true);
        for (int i = 0; i < extractedNodes.Count; i++)
        {
            // Skip first and last nodes
            if (i == 0 || i == extractedNodes.Count - 1)
                continue;
    
            // See if there is any bookmarks in this node
            Node node = (Node)extractedNodes[i];
            if (node.Range.Bookmarks.Count > 0)
                Console.WriteLine("Nested bookmark found");
        }
    }
