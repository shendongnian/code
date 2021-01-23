            //string[] input_Text = new string[] { "Ravi Kumar", "Ravi Kumar", "Ravi Kumar" }; 
            //string[] stopWords = new string[] { "Ravi" }; 
            for(int i=0;i<input_Text.Count();i++)
            {
                for (int j = 0; j < stopWords.Count(); j++)
                {
                       input_Text[i] = input_Text[i].Replace(stopWords[j]," ");
                }
            }
 
