     var str = "&lt;span class=\"street-address\"&gt;1805 Geary Boulevard&lt;/span&gt;, &lt;span class=\"locality\"&gt;San Francisco&lt;/span&gt;, &lt;span class=\"region\"&gt;CA&lt;/span&gt; &lt;span class=\"postal-code\"&gt;94115&lt;/span&gt;, &lt;span class=\"country-name\"&gt;United States&lt;/span&gt;".Replace("&lt;", "<").Replace("&gt;", ">");
            Regex regex = new Regex("<span class=\"street-address\">(.*)</span>, <span class=\"locality\">(.*)</span>, <span class=\"region\">(.*)</span> <span class=\"postal-code\">(.*)</span>, <span class=\"country-name\">(.*)</span>");
	        Match match = regex.Match(str);
            if (match.Success)
            {
                string address = match.Groups[1].Value;
                string locality = match.Groups[2].Value;
                string region = match.Groups[3].Value;
                string zip = match.Groups[4].Value;
                string country = match.Groups[5].Value;
             }
