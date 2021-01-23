    class Program
    {
        static void Main(string[] args)
        {
            byte[] array = new byte[] { 120, 100, 10, 120, 100, 10, 10, 60, 110 };
            List<byte[]> grouped = new List<byte[]>();
            // This loop will populate the list grouped with arrays of 3 bytes each, each representing an value for RGB
            for(int i = 0; i + 2 < array.Length; i += 3)
            {
                byte[] currentColor = new byte[]
                {
                    array[i],
                    array[i + 1],
                    array[i + 2]
                };
                grouped.Add(currentColor);
            }
            // Here you will remove repeated elements for RGB
            // Notice you will have to create the ByteArrayComparer class, you will find the code right under this one
            var noRepeatedElements = grouped.Distinct<byte[]>(new ByteArrayComparer());
            // Print the non repeated elements for testing purposes
            foreach(var rgb in noRepeatedElements)
            {
                foreach(var value in rgb)
                {
                    Console.Write($"\"{value}\"");
                }
            }
            Console.ReadKey();
        }
    }
