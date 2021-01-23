    public interface IPropertyChangedNotification<TDeclaringType>
    {
        TDeclaringType DeclaringObject { get; set; }
        string PropertyName { get; set; }
    }
    public interface IPropertyChangedNotification<TDeclaringType, out TPropertyType>
        :  IPropertyChangedNotification<TDeclaringType>
    {
        TPropertyType OldValue { get; }
        TPropertyType NewValue { get; }
    }
