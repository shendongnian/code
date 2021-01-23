    string input = @"Sprites\/tilesTest.png";
                string pattern = @"(\\)?(.png)?";
                string replacement = "";
                Regex rgx = new Regex(pattern);
                string result = rgx.Replace(input, replacement);
    
                Console.WriteLine("Original String: {0}", input);
                Console.WriteLine("Replacement String: {0}", result);
