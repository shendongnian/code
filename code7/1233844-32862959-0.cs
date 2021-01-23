      // Shallow copy (your actual implementation):
      // NewList is not b, but it contains to objects in b
      var NewList = b
        .Where(item => ...)
        .ToList(); 
    
      // Deep copy (which probably you're looking for)
      // NewList doesn't contain any reference to objects in b 
      var NewList = b
        .Where(item => ...)
        .Select(item => item.Clone()) // You need this
        .ToList(); 
