      // Shallow copy (your actual implementation):
      // NewList is not b, but it contains references to objects in b
      var NewList = b
        .Where(item => ...)
        .ToList(); 
    
      // Deep copy (which probably you're looking for)
      // NewList doesn't contain any reference to any objects in b 
      var NewList = b
        .Where(item => ...)
        .Select(item => item.Clone()) // You need this, proving that Clone() makes a deep copy
        .ToList(); 
