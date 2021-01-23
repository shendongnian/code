    [Test]
        public void Text()
        {
            string str = "[b]Hello[/b] This is sample text [b] Goodbye [/b]";
            var bold = AllIndexesOf(str, "b").ToArray();
            
            //assume the Ienumberable is even else it should of thrown an error
            for(int i = 0; i < bold.Count(); i += 2)
            {
                Console.WriteLine($"Pair: {bold[i]} | {bold[i+1]}");
            }
            //str.AllIndexesOf
          }
