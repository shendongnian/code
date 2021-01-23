    // Split the string on newlines
    string[] lines = theText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    
    // Process each line
    foreach(var line in lines){
      var words = line.Split(' ');
      var firstWord = parts[0];
      switch (firstWord){
        case "Price":
          Price = words[1];
          break;
        case "Take":
          Profit = words[words.Length - 1];
          break;
        // etc
      }
    }
