            static void getResults(string Text)
            {
                // X = lastIndexOf for ' ' (space)
                // x will take position of the last space
                // Results = substring
                // z will be the length of the string
                // z = text.Length
                //  Substring (x+1,z-x+1)
                StringReader reader = new StringReader(Text);
                List<string> Results = new List<string>();
                string inputLine = "";
                while ((inputLine = reader.ReadLine()) != null)
                {
                    Results.Add(inputLine.Trim());
                }
            }
    ​
