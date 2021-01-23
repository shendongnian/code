    class MultipartFormDataInMemoryStreamProvider : MultipartFormDataRemoteStreamProvider
    {
        public override RemoteStreamInfo GetRemoteStream(HttpContent parent, HttpContentHeaders headers)
        {
            return new RemoteStreamInfo(new MemoryStream(), string.Empty, string.Empty);
        }
    }
