    MongoClient client = new MongoClient( "mongodb://localhost:27017" );
    try
    {
        IMongoDatabase db = client.GetDatabase( "clientservertest" );
        try (
           db.GetStats();
           m_connected = true;
        catch (MongoConnectionException) {
           m_connected = false;
        }   
    }
    catch( Exception ) // Generic exception
    {
        m_connected = false;
    }
