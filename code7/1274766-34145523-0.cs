    private static Task<object> FooGet( ) {
    	return new Task<object>(innerTask);
	}
	
	private async static Task<object> innerTask() {
		await asyncBar( );
        return new object( );
	}
	
	private static async Task asyncBar( ){
	}
