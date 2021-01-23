    // setting the EffectParameterValues directly won't
    // set the IsDirty flag in this case
    public class EffectEditorControl : IEffectEditorControl
    {
        public object[] EffectParameterValues { get; set; }
        public bool IsDirty { get; set; }
        public IEffect TargetEffect { get; set; }
    }
    
