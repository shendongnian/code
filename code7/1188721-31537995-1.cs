     public class DerivedHost : ServiceHost
     {
	    public DerivedHost( Type t, params Uri baseAddresses ) :
		base( t, baseAddresses ) 
	    {
		    DisableMetadataExchange();
	    }
	    private void DisableMetadataExchange()
	    {
		    var metadata = Description.Behaviors.Find<ServiceMetadataBehavior>();
	
		    if metadata != null)
     		{
		    	// This code will disable metadata exchange
			    metadata .HttpGetEnabled = false; 
     			metadata .HttpsGetEnabled = false; 
		     }
     	}
     }
