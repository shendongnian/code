    [__DynamicallyInvokable]
    public string Query
    {
      [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get
      {
        return this.m_query;
      }
      [__DynamicallyInvokable] set
      {
        if (value == null)
          value = string.Empty;
        if (value.Length > 0)
          value = (string) (object) '?' + (object) value;
        this.m_query = value;
        this.m_changed = true;
      }
    }
