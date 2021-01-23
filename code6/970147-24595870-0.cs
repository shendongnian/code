    char[] characters = text.ToCharArray();
    for (int i = 0; i < characters.Length; i+=2) {
        characters[i] = char.ToUpper(characters[i]);
    }
    text = new string(characters);
