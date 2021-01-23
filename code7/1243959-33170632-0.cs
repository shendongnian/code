    class Program
    {
        static void Main(string[] args)
        {
            string source = "0x52341<element1 value=\"3\"><sub>1</sub></element1>0x234512 <element1><sub><element>2</element></sub></element1>0x52341<element2><sub>3</sub></element2> <element2><sub>4</sub></element2>0x4312";
            List<string> components = new List<string>();
            while (source.Length > 0)
            {
                int start = source.IndexOf('<');
                if (-1 == start)
                    break;
                int next = source.IndexOf("0x", start, StringComparison.OrdinalIgnoreCase);
                if (-1 == next)
                    break;
                components.Add(source.Substring(start, next - start));
                source = source.Substring(next);
            }
            foreach (string s in components)
                Console.WriteLine(s);
            Console.ReadLine();
        }
    }
