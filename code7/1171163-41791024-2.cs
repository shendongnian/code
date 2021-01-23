    /// <summary>
    /// Casts the result type of the input task as if it were covariant
    /// </summary>
    /// <typeparam name="T">The original result type of the task</typeparam>
    /// <typeparam name="TResult">The covariant type to return</typeparam>
    /// <param name="task">The target task to cast</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task<TResult> AsTask<T, TResult>(this Task<T> task) 
        where T : TResult 
        where TResult : class
    {
        return task.ContinueWith(t => t.Result as TResult);
    }
