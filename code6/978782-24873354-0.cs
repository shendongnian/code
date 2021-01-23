        static void Main(string[] args)
        {
            string content = "content;123 contents;456 contentss;789";
            Dictionary<string, int> result = new Dictionary<string, int>();
            content.Split(' ').ToList().ForEach(x =>
            {
                var items = x.Split(';');
                result.Add(items[0], int.Parse(items[1]));
            });
            foreach(var item in result)
            {
                Console.WriteLine("{0} -> {1}" , item.Key, item.Value);
            }
        }
