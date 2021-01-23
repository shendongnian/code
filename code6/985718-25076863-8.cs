    // this only lists all the members which a class must implement,
    // if it wants to implement the interface and pass compilation 
    public interface IEffectEditorControl
    {
        object[] EffectParameterValues { get; set; }  // <-- removed the statement
        bool IsDirty { get; set; }
        IEffect TargetEffect { get; set; }
    }
