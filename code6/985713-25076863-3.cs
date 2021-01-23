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
