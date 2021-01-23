    public void BasisChanged()
    {
        foreach (var p in GetType().GetProperties().Where(p => typeof(ThermodynamicProperty).IsAssignableFrom(p.PropertyType)))
        {
            var value = (ThermodynamicProperty)p.GetValue(this);
            if (!value.IsBasis)
                value.BasisChanged = true;
        }
    }
