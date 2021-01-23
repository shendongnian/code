    X509Certificate2 cert = ...
    if( cert.FriendlyName.Length == 0 ) {
        Console.WriteLine( "Certificate has no friendly name" );
    }
    else {
        Console.WriteLine( "Alias: " + cert.FriendlyName );
    }
