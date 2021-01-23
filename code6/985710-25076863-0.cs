    public interface IEffectEditorControl
    {
        object[] EffectParameterValues { get; set; }  // <-- removed the statement
        bool isDirty { get; set; }
        IEffect TargetEffect { get; set; }
    }
