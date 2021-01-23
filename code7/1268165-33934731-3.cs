      using System.Collections.Generic; // for Dictionary
      using System.Linq;                // Linq: ToDictionary
      ...
 
      String source = 
        "cn=54445sddsfsd,ou=99988855,o=fgfgfdg,u=dfddfgfgg.subject=5454gffdgfg454hg";
      Dictionary<String, String> data = source
        .Split(',')
        .ToDictionary(line => line.Substring(0, line.IndexOf('=')),
                      line => line.Substring(line.IndexOf('=') + 1));
