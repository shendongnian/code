            string input = "(Service=[MyCar]&(Type=[News]|Type=[Review]))";
            string pattern = @"Type=\[(News|Review|Video)\]";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach(Match match in matches)
            {
                foreach(Group group in match.Groups)
                {
                    Console.WriteLine(group);
                }
            }
