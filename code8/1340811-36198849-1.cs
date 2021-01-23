    List<Character> characters = new List<Character>();
    for(i = 0; i < 10; i++;)
    {
        Character character = new Character();
        character.Generate(); //A method that would randomly generate a new character
        characters.Add(character);
    }
