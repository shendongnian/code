	private static Task<object> FooGet( ){
		return new Task<object>( (Func<Task<object>>)( async ( ) => {
			await asyncBar( );
			return new object( );
		}
	}
