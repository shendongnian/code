    using System;
    using System.Text.RegularExpressions;
    String myString = toolStripTextBox1.Text;
    Regex myRegex = new Regex(@"www.\S+");
    Match myMatches = myRegex.Match(myString);
    if(myMatches.Groups.Count>0)return true;
