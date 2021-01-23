    void Flatten(Node element, Node parent = null)
    {
        for (var i = 0; i < element.Length; i++)
        {
            Flatten(element[i], element);
        }
            
        if (parent != null && element.Length > 0)
        {
            var children = element.Children.ToArray();
            var index = parent.IndexOf(element);
            parent.RemoveChild(element);
        
            foreach (var child in children)
            {
                element.RemoveChild(child);
                parent.InsertChild(index++, child);
            }
        }
    }
