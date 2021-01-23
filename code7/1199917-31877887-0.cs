    public class AvoidNullProps : LoopInjection
    {
        protected override void SetValue(object source, object target, PropertyInfo sp, PropertyInfo tp)
        {
            var val = sp.GetValue(source);
			if(val != null)
            tp.SetValue(target, val);
        }
    }
