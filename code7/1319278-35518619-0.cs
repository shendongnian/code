                string textBoxInput = "car test do bmw"; // Just a sample as I am using a console app
                string[] sentences = File.ReadAllLines("sentences.txt"); // Read all lines of a text file and assign it to a string array
                string[] keywords = textBoxInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // Split textBoxInput by space
                int[] matchArray = new int[sentences.Length];
    
                for(int i = 0; i < sentences.Length; i++)
                {
                    Regex regex = new Regex(@"\b(" + string.Join("|", keywords.Select(Regex.Escape).ToArray()) + @"+\b)", RegexOptions.IgnoreCase);
                    MatchCollection matches = regex.Matches(sentences[i]);
                    matchArray[i] = matches.Count;
                }
    
                int highesMatchIndex = Array.IndexOf(matchArray, matchArray.OrderByDescending(item => item).First());
                
                Console.WriteLine("User input: " + textBoxInput);
                Console.WriteLine("Matching sentence: " + sentences[highesMatchIndex]);
                Console.WriteLine("Match count: " + matchArray[highesMatchIndex]);
    
                Console.ReadLine();
