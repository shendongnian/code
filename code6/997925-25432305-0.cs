    public List<string> getIP(string myString)
        {
            List<string> myString = new List<string>();
            // use Regex.Matches to get all the string parts that match for an IP adress
            MatchCollection matchs = Regex.Matches(input, @"\d+\.\d+\.\d+\.\d+", RegexOptions.IgnoreCase);
            //collect all the strings that matches
            foreach (Match match in matchs)
            {
                output.Add(match.Value);
            }
            //finaly! return the result as a list
            return output;
        }
