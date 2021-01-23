    /// <summary>
    /// Releases all resources that are used by the current instance of the <see cref="T:System.Web.Mvc.Controller"/> class.
    /// </summary>
    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }
    /// <summary>
    /// Releases unmanaged resources and optionally releases managed resources.
    /// </summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
    }
