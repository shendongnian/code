	/// <summary>
	/// Ping the specified db.
	/// </summary>
	private bool Ping( IMongoDatabase db )
	{
		Console.WriteLine( "Checking mongodb connection..." );
		Task<BsonDocument> pingTask = db.RunCommandAsync<BsonDocument>( new BsonDocument( "ping", 1 ) );
		pingTask.Wait( 1000 ); // more than one second is way too much - db should be on same computer
		if( pingTask.IsCompleted )
		{
			Console.WriteLine( "...connection ok." );
			return true;
		}
		else
		{
			Console.WriteLine( "...connection FAILED." );
			return false;
		}
	}
