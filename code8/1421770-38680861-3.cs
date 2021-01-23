    using System;
    using System.Collections.Generic;
    
    public class stringParser
    {
        private struct IndexElements 
        {
            public int start;
            public int end;
            public string value;
        }
    
        public static void Main()
        {   
            //input string
            string myString = "子で子にならぬ時鳥,0:こ;2:こ;7-8:ほととぎす";
            int wordIndexSplit = myString.IndexOf(',');
            string word = myString.Substring(0,wordIndexSplit);
            string indices = myString.Substring(wordIndexSplit + 1);
    
            string[] eachIndex = indices.Split(';');
            Dictionary<int,IndexElements> index = new Dictionary<int,IndexElements>();
            string[] elements;
            IndexElements e;
            int dash;
            int n = 0;
            int last = -1;
            string results = "";
    
            foreach (string s in eachIndex)
            {
                e = new IndexElements();
                elements = s.Split(':');
                if (elements[0].Contains("-"))
    	        {
                    dash = elements[0].IndexOf('-');
                    e.start = int.Parse(elements[0].Substring(0,dash));
                    e.end = int.Parse(elements[0].Substring(dash + 1));
    	        }
                else
    	        {
                    e.start = int.Parse(elements[0]);
                    e.end = e.start;
    	        }
                e.value = elements[1];
    
                index.Add(n,e);
                n++;
            }
    
            //this is the part that takes the "setup" from the parts above and forms the result string
            //loop through each of the "indices" parsed above
            for (int i = 0; i < index.Count; i++)
            {
                //if this is the first iteration through the loop, and the first "index" does not start 
                //at position 0, add the beginning characters before its start
                if (last == -1 && index[i].start > 0)
                {
                    results += word.Substring(0,index[i].start);
                }
                //if this is not the first iteration through the loop, and the previous iteration did
                //not stop at the position directly before the start of the current iteration, add
                //the intermediary chracters
                else if (last != -1 && last + 1 != index[i].start)
                {
                    results += word.Substring(last + 1,index[i].start - (last + 1));
                }
    
                //add the space before the "index" match, the actual match, and then the formatted "index"
                results += " " + word.Substring(index[i].start,(index[i].end - index[i].start) + 1)
                    + "[" + index[i].value + "]";
                //remember the position of the ending for the next iteration
                last = index[i].end;
            }
    
            //if the last "index" did not stop at the end of the input string, add the remaining characters
            if (index[index.Keys.Count - 1].end + 1 < word.Length)
            {
                results += word.Substring(index[index.Keys.Count-1].end + 1);
            }
            //trimming spaces that may be left behind
            results = results.Trim();
    
            Console.WriteLine("INPUT  - " + myString);
            Console.WriteLine("OUTPUT - " + results);
    
            Console.Read();
        }
    }
input  - 子で子にならぬ時鳥,0:こ;2:こ;7-8:ほととぎす
output - 子[こ]で 子[こ]にならぬ 時鳥[ほととぎす]
