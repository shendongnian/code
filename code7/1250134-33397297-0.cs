    SortedDictionary<string, int> sd = new SortedDictionary<string, int>();
            foreach(DynamicNode thingToDo in thingsToDo)
            {
                List<char> temp = new List<char>();
                char[] parseWord = thingToDo.Name.ToCharArray();
                var brokenWord = parseWord.Select(x => x == 8203);
    
                var enumeratorWord = parseWord.GetEnumerator();
                var enumeratorBool = brokenWord.GetEnumerator();
                enumeratorBool.MoveNext();
                 while(enumeratorWord.MoveNext())
                 {
                     if(!(bool)enumeratorBool.Current)
                     {
                         temp.Add((char)enumeratorWord.Current);
                     }
                 }
                 var result = string.Join("", temp.ToArray());
                 sd.Add(result, thingToDo.Id);   
            }
