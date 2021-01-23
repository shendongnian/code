    public static class IEffectEditorControlExtension
    {
        public static void SetParametersAndMarkAsDirty
            (this IEffectEditorControl obj, object[] value)
        {
            obj.EffectParameterValues = value;
            obj.IsDirty = true;
        }
    }
    
