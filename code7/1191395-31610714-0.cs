    using System.Text.RegularExpressions;
    Regex re = new Regex("hl[1|2|3|4|5|6|7]");
    string[] test=  {"hl1","hl2","hl3","hl4","hl5","hl6","hl7","hlasdfasdf"};
    for(int i = 0; i < test.Length; i++){
        System.Console.WriteLine(test[i] + ":" + (re.IsMatch(test[i])?"match":"does not match"));
    }
