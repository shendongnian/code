        private IEnumerator _HandleResult<T>(object closure, System.Action<string> onError)
        {
            yield return webRequest;
            // Can't do a switch statement on Type, needs to be if/else chain :(
            if (true)
            {
                if (typeof(T) == typeof(Texture))
                    ((System.Action<Texture>)closure)(webRequest.texture);
                else if (typeof(T) == typeof(string))
                    ((System.Action<string>)closure)(webRequest.text);
                else if (typeof(T) == typeof(MovieTexture))
                    ((System.Action<MovieTexture>)closure)(webRequest.movie);
                else if (typeof(T) == typeof(byte[]))
                    ((System.Action<byte[]>)closure)(webRequest.bytes);
                else
                    throw new System.NotSupportedException("Could not interpret response data as " + typeof(T).Name + ". Supported types include Texture, MovieTexture, byte[] and string.");
            }
        }
