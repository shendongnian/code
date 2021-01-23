    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<Color, string>
            {
                { Color.Red, "#FF0000" },
                { Color.Green, "#00FF00" },
                { Color.Blue, "#0000FF" },
                { Color.White, "#FFFFFF" }
            };
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new CustomResolver();
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(dict, settings);
            Console.WriteLine(json);
        }
        enum Color { Red = 1, Green = 2, Blue = 3, White = 4 }
    }
