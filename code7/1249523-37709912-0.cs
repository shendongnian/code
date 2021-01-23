    public class PropertyAndFieldInjection : ValueInjection
    {
        protected string[] ignoredProps;
        public PropertyAndFieldInjection()
        {
        }
        public PropertyAndFieldInjection(string[] ignoredProps)
        {
            this.ignoredProps = ignoredProps;
        }
        protected override void Inject(object source, object target)
        {
            var sourceProps = source.GetType().GetProps();
            foreach (var sourceProp in sourceProps)
            {
                Execute(sourceProp, source, target);
            }
            var sourceFields = source.GetType().GetFields();
            foreach (var sourceField in sourceFields)
            {
                Execute(sourceField, source, target);
            }
        }
        protected virtual void Execute(PropertyInfo sp, object source, object target)
        {
            if (!sp.CanRead || sp.GetGetMethod() == null || (ignoredProps != null && ignoredProps.Contains(sp.Name)))
                return;
            var tp = target.GetType().GetProperty(sp.Name);
            if (tp != null && tp.CanWrite && tp.PropertyType == sp.PropertyType && tp.GetSetMethod() != null)
            {
                tp.SetValue(target, sp.GetValue(source, null), null);
                return;
            }
            var tf = target.GetType().GetField(sp.Name);
            if (tf != null && tf.FieldType == sp.PropertyType)
            {
                tf.SetValue(target, sp.GetValue(source, null));
            }
        }
        protected virtual void Execute(FieldInfo sf, object source, object target)
        {
            if (ignoredProps != null && ignoredProps.Contains(sf.Name))
                return;
            var tf = target.GetType().GetField(sf.Name);
            if (tf != null && tf.FieldType == sf.FieldType)
            {
                tf.SetValue(target, sf.GetValue(source));
                return;
            }
            var tp = target.GetType().GetProperty(sf.Name);
            if (tp != null && tp.CanWrite && tp.PropertyType == sf.FieldType && tp.GetSetMethod() != null)
            {
                tp.SetValue(target, sf.GetValue(source), null);
            }
        }
    }
