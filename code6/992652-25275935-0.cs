    string input = new WebClient().DownloadString(@"http://eu.battle.net/wow/en/character/Kazzak/Ierina/simple");
            // Here we call Regex.Match for <span class="equipped">560</span>
            Match match = Regex.Match(input, @"<span class=\""equipped\"">([0-9]+)</span>",
                RegexOptions.IgnoreCase);
            // Here we check the Match instance.
            if (match.Success)
            {
                
                 string key = match.Groups[1].Value; //result here
            
            }
