    public interface ISession : IDisposable
    {
        ...
        /// <summary>
        /// Determines at which points Hibernate automatically flushes the session.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// For a readonly session, it is reasonable to set the flush mode 
        ///  to <c>FlushMode.Never</c>
        ///  at the start of the session (in order to achieve some 
        ///       extra performance).
        /// 
        /// </remarks>
        FlushMode FlushMode { get; set; }
