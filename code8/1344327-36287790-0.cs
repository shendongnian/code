	HttpRequestMessage hrh = new HttpRequestMessage();
	HttpHeaders headers = hrh.Headers;
	headers.Add( "ALLCAPS", "thevalue" );
	IEnumerable<string> headerValues;
	bool success = headers.TryGetValues( "allcaps", out headerValues );
	Assert.IsTrue( success );
	Console.Out.WriteLine( String.Join( ",", headerValues ) );
    // thevalue
