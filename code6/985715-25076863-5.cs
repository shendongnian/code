    // whichever code accepts the interface IEffectEditorControl,
    // can now accept this concrete implementation (and you can have 
    // multiple classes implementing the same interface)
    public class EffectEditorControl : IEffectEditorControl
    {
        private object[] _effectParameterValues; 
        public object[] EffectParameterValues
        {
            get
            { 
                return _effectParameterValues;
            }
            set
            { 
                _effectParameterValues = value;
                IsDirty = true;
            }
        }
        
        public bool IsDirty { get; set; }
        public IEffect TargetEffect { get; set; }
    }
