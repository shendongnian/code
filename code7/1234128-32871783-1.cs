    static void Main(string[] args)
    {
        string[] names = new string[] { "john", "samuel", "george", "steve", "martyn" };
    
        foreach (var name in names)
        {
            string withoutVowels = new string(name.Where(x => !"aeiou".Contains(x)).ToArray());
            Console.WriteLine("The output is: " + withoutVowels);
        }
        Console.ReadKey();
    }
