    var outerNode = l.First;
    while (outerNode != null) {
        var innerNode = outerNode.Value.First;
        while (innerNode != null) {
            Console.Write(innerNode.Value.data);
            Console.Write(" ");
            innerNode = innerNode.Next;
        }
        Console.Write("\n");
        outerNode = outerNode.Next;
    }
        
