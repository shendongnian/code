    /// <summary>This is the asynchronous version of <see cref="M:System.Data.Common.DbCommand.ExecuteNonQuery" />. Providers should override with an appropriate implementation. The cancellation token may optionally be ignored.The default implementation invokes the synchronous <see cref="M:System.Data.Common.DbCommand.ExecuteNonQuery" /> method and returns a completed task, blocking the calling thread. The default implementation will return a cancelled task if passed an already cancelled cancellation token.  Exceptions thrown by <see cref="M:System.Data.Common.DbCommand.ExecuteNonQuery" /> will be communicated via the returned Task Exception property.Do not invoke other methods and properties of the <see langword="DbCommand" /> object until the returned Task is complete.</summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="T:System.Data.Common.DbException">An error occurred while executing the command text.</exception>
    public virtual Task<int> ExecuteNonQueryAsync(CancellationToken cancellationToken)
    {
      ...
      return Task.FromResult<int>(this.ExecuteNonQuery());
      ...
    }
