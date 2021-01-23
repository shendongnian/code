    private static readonly Random random = new Random();
    public static void Main(string[] args)
    {
        var data =
            "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
        Console.WriteLine(GetRandomWords(data, 5));
        Console.ReadLine();
    }
    
    private static string GetRandomWords(string data, int x)
    {
        // Split data into words.
        var words = data.Split(' ');
        // Find a random place to start, at least x words back.
        var start = random.Next(0, words.Length - x);
        // Select the words.
        var selectedWords = words.Skip(start).Take(x);
        return string.Join(" ", selectedWords);
    }
