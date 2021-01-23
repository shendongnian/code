        public static string splitByLength(string sentance, int length)
        {
            //Split the sentance up into individual words to add to a sentance
            var words = sentance.Split(' ');
            StringBuilder ret = new StringBuilder();
            StringBuilder line = new StringBuilder();
            //loop through every word
            foreach (var word in words)
            {
                //And add each one with a space at the end
                line.Append(word + " ");
                //If we have reached the end of a line or we have the last word
                if(line.Length >= length || word == words.Last())
                {
                    //add the line to the results
                    ret.AppendLine(line.ToString());
                    //start new line
                    line.Clear();
                }
            }
            return ret.ToString();
        }
