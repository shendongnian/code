      // list.Count is just a integer field, a very cheap comparison 
      if (list.Count != 1) {
        // 0 or many items (not a single one)
        ...
      }
      else {
        // list contains exactly one item 
        var item = list[0]; 
        ...
      }
