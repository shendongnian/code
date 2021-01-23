    /// <summary>
    /// Abstract modelling class for NER tagging - overridden by specific named entities. Used here so that all classes inherit from a single base class - polymorphic list
    /// </summary>
    protected string _name;
    public abstract string Name { get; set; }
}
