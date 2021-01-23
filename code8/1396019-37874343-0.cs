    // This is very important part and the reason why I believe mentioned
    // PerCallContext implementation is wrong.
    private readonly Guid _key = Guid.NewGuid();
    public override object GetValue()
    {
        return HttpContext.Current.Items[_key];
    }
    public override void SetValue(object newValue)
    {
        HttpContext.Current.Items[_key] = newValue;
    }
    public override void RemoveValue()
    {
        var obj = GetValue();
        HttpContext.Current.Items.Remove(obj);
    }
