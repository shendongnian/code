    using System.Text.RegularExpressions;
    
    string pattern = "^(?:(?<cn>CN=(?<name>[^,]*)),)?(?:(?<path>(?:(?:CN|OU)=[^,]+,?)+),)?(?<domain>(?:DC=[^,]+,?)+)$";
    string dn = "CN=Exchange Servers,OU=Microsoft Exchange Security Groups,DC=gr-u,DC=it";
    Match match = Regex.Matches(myDN, pattern)(0);
    Console.WriteLine(match.Groups("cn").Value);
     // output: 
     // CN=Help Desk
    
    Console.WriteLine(match.Groups("name").Value);
     // output:
     // Help Desk
    Console.WriteLine(match.Groups("path").Value);
     // output:
     // OU=Microsoft Exchange Security Groups
    
    Console.WriteLine(match.Groups("domain").Value);
     // output:
     // DC=gr-u,DC=it
