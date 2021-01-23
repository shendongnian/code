    public class SensitiveDataProvider : IValueProvider
    {
        readonly string sesitiveDatatag = "Sensitive Data";
        public object GetValue(object target)
        {
            return sesitiveDatatag;
        }
        public void SetValue(object target, object value)
        {
            target = sesitiveDatatag;
        }
    }
