    /// <summary>
    /// Used to bind a source stream to destination stream
    /// Clients can subscribe to the destination stream before the source stream has been bound.
    /// The source stream can be changed as desired without affecting the subscription to the destination stream.
    /// </summary>
    public class BindableStream<T> : IObservable<T>
    {
        /// <summary>
        /// Subject used as the destination stream.
        /// For passing data from source to dest stream.
        /// This is a stream of streams.
        /// When a new stream is added it replaces whichever stream was previously added.
        /// </summary>
        private Subject<IObservable<T>> destStream = new Subject<IObservable<T>>();
        /// <summary>
        /// Subscribe to the destination stream.
        /// Clients can subscribe to this to receive data that is passed on from the source stream.
        /// Later on we can set or change the underlying source stream without affecting the destination stream.
        /// </summary>
        public IDisposable Subscribe(IObserver<T> observer)
        {
            return destStream.Switch().Subscribe(observer);
        }
        /// <summary>
        /// Bind to a new source stream that is to be propagated to the destination stream.
        /// </summary>
        public void Bind(IObservable<T> sourceStream)
        {
            destStream.OnNext(sourceStream);
        }
        /// <summary>
        /// Unbind the source stream.
        /// </summary>
        public void Unbind()
        {
            destStream.OnNext(Observable.Empty<T>());
        }
    }
