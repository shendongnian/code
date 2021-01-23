    _DbContext.Nodes
        // filter nodes with any of the input tags
        .Where(n => n.Tags.Any(t => tags.Contains(t.DisplayName)))
        // select the information required
        .Select(n => new {
            n.NodeNativeId, 
            n.NodeName, 
            ClassName = n.NodeClass.ClassName,
            TagNames = n.Tags.Select(t => t.DisplayName) })
        // materialize super set with database
        .ToList()
        // filter so that only nodes with all tags remain
        .Where(n => !tags.Except(n.TagNames).Any())
        // produce result in anonymous class
        .Select(n => new { n.NodeNativeId, n.NodeName, n.ClassName })
        .ToList();
        
