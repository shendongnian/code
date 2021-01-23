    static class Extensions {
        public static IObservable<byte[]> AsyncRead(this Stream stream, int bufferSize) {           
            var buffer = new byte[bufferSize];            
            var asyncRead = Observable.FromAsyncPattern<byte[], int, int, int>(
                stream.BeginRead,
                stream.EndRead);
            return Observable.While(
                () => stream.CanRead,
                Observable.Defer(() => asyncRead(buffer, 0, bufferSize))
                    .Select(readBytes => buffer.Take(readBytes).ToArray()));
        }
    }
