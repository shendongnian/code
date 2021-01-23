    string spaces10 = new string(' ', 10);
    string spaces3 = new string(' ', 3);
    string input_file = Console.ReadLine();
    Console.Write("Enter Location:");
    string output_file = Console.ReadLine();
    using (StreamReader sr = File.OpenText(input_file))
    {
        using (TextWriter sw = File.CreateText(output_file))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string first_part = line.Substring(0, 20);
                string second_part = line.Substring(20);
                string result = spaces10 + first_part + spaces3 + second_part;
                sw.WriteLine(result);
            }
        } 
    }
    Console.ReadKey();
