    string str = "Alameer Ashraf Hassan Alameer ashraf,elnagar.";
            string[] CorpusResult = str.Split(' ', ',', '.');
           //Creating the Dictionary to hold up each word as key & its occurance as Value  ......! 
            Dictionary<string, int> Dict = new Dictionary<string, int>();
           //loopnig over the corpus and fill the dictionary in .........!
            foreach (string item in CorpusResult)
            {
    			if (string.IsNullOrEmpty(item)) continue;
    			
                if (Dict.ContainsKey(item))
    			{
    				Dict[item]++;
    			}
    			else
    			{
    				Dict.Add(item, 1);
    			}
    		}
            Console.WriteLine("Method 1: ");
            foreach (var item in Dict)
            {
                Console.WriteLine(item.Value);
            }
    		
    		Console.WriteLine("Method 2: ");
    		foreach(var k in Dict.Keys)
    		{
    			Console.WriteLine(Dict[k]);
    		}
