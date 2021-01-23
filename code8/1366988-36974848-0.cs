    public static Pokemon[] PokeBox(int PokeAnzahl)
    {
        Pokemon[] Pokemons = new Pokemon[PokeAnzahl];
        Console.WriteLine("Enter {0} different Pokemons: ", PokeAnzahl);
        for (int i = 0; i < PokeAnzahl; i++)
        {
             ...
        }
        return Pokemons;
    }
    public static void ShowPokeBox(Pokemon[] Pokemons)
    {
        ...
    }
    static void Main(string[] args)
    {
        ...
        var Pokemons = PokeBox(PokeAnzahl);
        ShowPokeBox(Pokemons);
    }    
