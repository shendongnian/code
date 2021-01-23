    DateTime A = DateTime.Parse("2015-07-04T02:00:00+03:00");
    DateTime B = DateTime.Parse("2015-07-03T18:00:00-07:00");
    
    Console.WriteLine(A.ToUniversalTime().ToString("'A: 'yyyy'-'MM'-'dd hh:mm:ss"));
    Console.WriteLine(B.ToUniversalTime().ToString("'B: 'yyyy'-'MM'-'dd hh:mm:ss"));
    Console.WriteLine( B > A );
    
    A = DateTime.Parse("2015-11-01T01:00:00-07:00");
    B = DateTime.Parse("2015-11-01T01:00:00-08:00");
    
    Console.WriteLine(A.ToUniversalTime().ToString("'A: 'yyyy'-'MM'-'dd hh:mm:ss"));
    Console.WriteLine(B.ToUniversalTime().ToString("'B: 'yyyy'-'MM'-'dd hh:mm:ss"));
    Console.WriteLine( B > A );
