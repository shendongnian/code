    public IEnumerable<Flight> GetFlights() {
    	// dbContexts is an IEnumerable<DbContext> that was injected in the constructor
    	foreach (var ctx in dbContexts) {
    		foreach (var flight in ctx.Flights) {
    			yield return flight;
    		}
    	}
    }
