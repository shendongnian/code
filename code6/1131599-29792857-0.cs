      string a = "<a onclick=\"ClearInfoAndDataTable();\" href=\"/xyz.com?target=www.homeocare.in\">1,945</a>";
      System.Text.RegularExpressions.Regex r = new   System.Text.RegularExpressions.Regex("(<a[^>]*>)(.[^<]*)");
      string rs = "(<a[^>]*>)(.[^<]*)";
      
      System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(a, rs);
      Console.WriteLine(match.Groups[2].Value);
