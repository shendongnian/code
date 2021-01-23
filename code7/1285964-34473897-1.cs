    public static class ListExtension
    {
        public static void Show<T>(this List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
