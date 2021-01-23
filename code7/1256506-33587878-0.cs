            Regex regex = new Regex(@"[1-9][0-9]*\.?[0-9]*([Ee][+-]?[0-9]+)?");
            string testString ="1/(2.342/x) * x^3.45";
            MatchCollection collection = regex.Matches(testString);
            foreach(Match item in collection)
            {
                double extract =Convert.ToDouble(item.Value);
                //change your decimal here...
                testString = testString.Replace(item.Value, extract.ToString());
            }
        
