        static void Main(string[] args)
        {
            string text = @" Today is a very ""nice"" and hot day. Second sentense with ""text"" test";
            var foundIndexes = new List<int>();
            foundIndexes.Add(0);
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '"') 
                    foundIndexes.Add(i);
            }
            string result = "";
            
            for(int i =0; i<foundIndexes.Count; i+=2)
            {
                int length = 0;
                
                if(i == foundIndexes.Count - 1)
                {
                    length = text.Length - foundIndexes[i];
                }
                else
                {
                    length = foundIndexes[i + 1] - foundIndexes[i]+1;
                }
                result += text.Substring(foundIndexes[i], length);
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
