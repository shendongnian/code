    /// <devdoc>
    /// <para>Returns an enumerator that can iterate through the <see cref='System.Collections.Specialized.NameObjectCollectionBase'/>.</para>
    /// </devdoc>
    public virtual IEnumerator GetEnumerator() {
        return new NameObjectKeysEnumerator(this);
    }
