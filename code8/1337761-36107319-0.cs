    string[] words = File.ReadAllLines("Palabras.txt");
    string[] definitions = File.ReadAllLines("Definiciones.txt");
    
    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    
    for(int i = 0; i < words.Length; i++)
    {
        dictionary.Add(words[i], definitions[i]);
    }
    
    string output = dictionary["programmer"]; // "A person who writes computer programs"
