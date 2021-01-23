    public interface IEffectEditorControl
    {
        object[] EffectParameterValues { get; set; }  // <-- removed the statement
        bool IsDirty { get; set; }
        IEffect TargetEffect { get; set; }
    }
