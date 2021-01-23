      List<string> nouns = new List<string> { 
        "man[1]", "woman[2]", "cat[3]", "house[4]", "rat[5]", "prison[6]"};
      List<string> descriptions = new List<string> { 
        "is alive[1][2][3][5]", 
        "is made of bricks[4][6]", 
        "is an animal[3][5]", 
        "is a building[4][6]", 
        "is female[2][3][5]", 
        "is a word [1][2][3][4][5][6]" };
      // parsed dictionary of entry indice
      var dict = descriptions
        .Select(item => item.Split(new Char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries))
        .SelectMany(items => items.Skip(1).Select(item => new {
          name = items[0],
          id = int.Parse(item) }))
        .GroupBy(pair => pair.id, pair => pair.name)
        .ToDictionary(item => item.Key, item => item);
      var result = nouns
        .Select(item => item.Split(new Char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries))
        .SelectMany(items => items.Skip(1).Select(item => new {
          name = items[0],
          id = int.Parse(item)}))
        .SelectMany(pair => dict[pair.id].Select(item => pair.name + " " + item));
