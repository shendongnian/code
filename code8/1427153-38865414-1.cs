    /// <summary>Gets or sets whether ordered processing should be enforced on a block's handling of messages.</summary>
    /// <remarks>
    /// By default, dataflow blocks enforce ordering on the processing of messages. This means that a
    /// block like <see cref="TransformBlock{TInput, TOutput}"/> will ensure that messages are output in the same
    /// order they were input, even if parallelism is employed by the block and the processing of a message N finishes 
    /// after the processing of a subsequent message N+1 (the block will reorder the results to maintain the input
    /// ordering prior to making those results available to a consumer).  Some blocks may allow this to be relaxed,
    /// however.  Setting <see cref="EnsureOrdered"/> to false tells a block that it may relax this ordering if
    /// it's able to do so.  This can be beneficial if the immediacy of a processed result being made available
    /// is more important than the input-to-output ordering being maintained.
    /// </remarks>
    public bool EnsureOrdered
    {
        get { return _ensureOrdered; }
        set { _ensureOrdered = value; }
    }
