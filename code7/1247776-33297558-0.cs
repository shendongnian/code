        string s1="Hey <span class=\"OverLayStyle\" style=\"background-color:#d8dfea\">@Peter</span> and <span class=\"OverLayStyle\" style=\"background-color:#d8dfea\">@cara</span>";
        string s2 = "Do you like <span class=\"OverLayStyle\" style=\"background-color:#d8dfea\">#Facebook</span>  or <span class=\"OverLayStyle\" style=\"background-color:#d8dfea\">#Google</span> ?";
        var sb=new StringBuilder();
        var parts = s1.Split(new string[] { "</span>" },StringSplitOptions.RemoveEmptyEntries);
        foreach (var s in parts) {
            if (s.Contains('@'))
                sb.Append(s.Replace("<span ", "<a href=\"\" ") + "</a>");
            else
                sb.Append(s + "</span>"); 
        }
        var resultOfs1 = sb.ToString();
        /*
        Hey <a href="" class="OverLayStyle" style="background-color:#d8dfea">@Peter</a> and <a href="" class="OverLayStyle" style="background-color:#d8dfea">@cara</a> 
        */
        sb.Clear();
        parts = s2.Split(new string[] { "</span>" }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var s in parts) {
            if (s.Contains('@'))
                sb.Append(s.Replace("<span ", "<a href=\"\" ") + "</a>");
            else
                sb.Append(s + "</span>");
        }
        var resultOfs2 = sb.ToString();
        /*
        Do you like <span class="OverLayStyle" style="background-color:#d8dfea">#Facebook</span>  or <span class="OverLayStyle" style="background-color:#d8dfea">#Google</span> ?</span> 
        */
