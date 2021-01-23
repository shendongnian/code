    public override void ApplyValue(string property, object value, int? index)
    {
        object target = Data;
        var pi = target.GetType().GetProperty(property);
        if (index.HasValue && pi.GetIndexParameters().Length != 1)
        {
            target = pi.GetValue(target, null);
            pi = target.GetType().GetProperties()
                .First(p => p.GetIndexParameters().Length == 1
                && p.GetIndexParameters()[0].ParameterType == typeof(int));
        }
        pi.SetValue(target, value, index.HasValue ? new object[] { index.Value } : null);
    }
