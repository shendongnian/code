    char characterToFind = 'r';
    string s = "Hello world!";
    int index = 0; // because foreach won't use any int i = 0 method
    foreach (char c in s) { // foreach character in the string
      // read the character and post the output
      if(c == characterToFind) {
        Console.Write("Character found at: " + index.ToString());
      }
      index++; // increment
    }
