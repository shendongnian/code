     class Program
        {
            static void Main(string[] args)
            {
                String[] list = new String[] { "BB", "CC", "AA", "BB", "CC", "DD", "AA", "EE", "CC", "FF" };
                List<String> distinct = list.Distinct().ToList();
                foreach (var item in distinct)
                {
                    Console.WriteLine(item);
                }
                Console.Read();
            }
        }
    Output: 
    BB
    CC
    AA
    DD
    EE
    FF
