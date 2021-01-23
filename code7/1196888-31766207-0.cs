    static void Main(string[] args)
            {
                string name = "Jesse";
                int courseNum = 230;
                int num = 23130;
                decimal d = 123456789.54321M;
    
                string combined = name + courseNum + num + d;
                string bitString = GetBits(combined);
                System.IO.File.WriteAllText(@"your_full_path_with_exiting_text_file", bitString);
                Console.ReadLine();
            }
