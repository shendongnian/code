    var lines = new List<string> { 
    	"Fr 23:59:59 M40 N04161K RX LAG 2 JNYT  17 STORE OCC 1 PRUD 1 RAW  -9 LAG   0",
    	"Fr 23:59:59 M08  N09461M  %SAT   3  %CONG   0  MQ 0  EB 0  OSQ     0 NSQ     4",
    	"Fr 23:59:59 M20 N09461M SAT   3%  SQ     0  FLOW     4  GN  13  STOC  9"
    };
    var options = RegexOptions.IgnorePatternWhitespace;
    var regex = new Regex("(?: ^\\w\\w | -?\\b\\d+\\b )", options );
    
    foreach (var l in lines ){
    	var matches = regex.Matches( l );
    	
    	foreach(Match m in matches){
    		Console.Write( "{0},", m.Value );
    	}
    	Console.WriteLine();
    }
