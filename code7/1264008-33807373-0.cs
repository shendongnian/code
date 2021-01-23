    string gby = "NOM";
    //string gby = "DDN";
    //string gby = "VILLE";
    var qry = _liste
                 .GroupBy(x => {
                    string result = "";
                    switch (gby) 
                    
                    {
                      case "NOM": result = x._NOM; break;
                      case "DDN" : result = x._DDN.ToString(); break;
                      case "VILLE" : result = x._VILLE ; break;
                    }
                    return result;
                }
                ).ToList();
