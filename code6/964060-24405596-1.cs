    /// <summary>
    /// Update the persistent instance with the identifier of the given transient instance.
    /// </summary>
    /// <remarks>
    /// If there is a persistent instance with the same identifier, an exception is thrown. If
    /// the given transient instance has a <see langword="null" /> identifier, an exception will be thrown.
    /// </remarks>
    /// <param name="obj">A transient instance containing updated state</param>
    void Update(object obj);
