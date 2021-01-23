    private IEnumerator _HandleResult<T> (System.Action<T> closure, System.Action<string> onError){
        yield return webRequest;
        if (SuccessWithoutErrors(onError)) {
	        if(typeof(T) == typeof(Texture))
				closure((T)(object)webRequest.texture);
			else if(typeof(T) == typeof(string))
				closure((T)(object)webRequest.text);
			else if(typeof(T) == typeof(MovieTexture))
				closure((T)(object)webRequest.movie);
			else if(typeof(T) == typeof(byte[]))
				closure((T)(object)webRequest.bytes);
			else
				throw new System.NotSupportedException("Could not interpret response data as " + typeof(T).Name + ". Supported types include Texture, MovieTexture, byte[] and string.");
		}
	}
