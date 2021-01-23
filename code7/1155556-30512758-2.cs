        class Link
        {
            public Node First {get; set;}
            public Node Second {get; set;}
            public string Name {get; set;}
            public double Length {get; set;}
            public double Strength {get; set;}
        }
    
        class Node
        {
            public IList<Link> Links {get; set;}
            //...
        }
