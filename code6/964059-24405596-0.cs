    /// <summary>
    /// Update the persistent state associated with the given identifier.
    /// </summary>
    /// <remarks>
    /// An exception is thrown if there is a persistent instance with the same identifier
    /// in the current session.
    /// </remarks>
    /// <param name="obj">A transient instance containing updated state</param>
    /// <param name="id">Identifier of persistent instance</param>
    void Update(object obj, object id);
    
    /// <summary>
    /// Update the persistent instance with the identifier of the given detached
    /// instance.
    /// </summary>
    /// <param name="entityName">The Entity name.</param>
    /// <param name="obj">a detached instance containing updated state </param>
    /// <remarks>
    /// If there is a persistent instance with the same identifier,
    /// an exception is thrown. This operation cascades to associated instances
    /// if the association is mapped with <tt>cascade="save-update"</tt>.
    /// </remarks>
    void Update(string entityName, object obj);
