    _DbContext.Nodes
        .Where(n => n.Tags.Any(t => tags.Contains(t.DisplayName))
        .Select(n => new {
            n.NodeNativeId, 
            n.NodeName, 
            ClassName = n.NodeClass.ClassName,
            TagNames = n.Tags.Select(t => t.DisplayName) })
        .ToList() // get superset
        .Where(n => !tags.Except(n.TagNames).Any()) // get nodes with all tags
        .Select(n => new { n.NodeNativeId, n.NodeName, n.ClassName })
        .ToList();
        
