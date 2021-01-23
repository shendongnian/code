    private static void AttachProperties<T1,T2>(Expression<Func<T1, object>> property1, T1 instance1, Expression<Func<T2, object>> property2,  T2 instance2)
                where T1 : INotifyPropertyChanged
                where T2 : INotifyPropertyChanged
    {
        var p1 = property1.GetPropertyInfo();
        var p2 = property2.GetPropertyInfo();
    
            //A NULL or empty PropertyName in PropertyChangeEventArgs means that all properties changed
            //See: https://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged.propertychanged(v=vs.110).aspx#Anchor_1
            ((INotifyPropertyChanged)instance1).PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == p1.Name || string.IsNullOrEmpty(e.PropertyName))
                {
                    SyncProperties(p1, p2, instance1, instance2);
                }
            };
            ((INotifyPropertyChanged)instance2).PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == p2.Name || string.IsNullOrEmpty(e.PropertyName))
                {
                    SyncProperties(p2, p1, instance2, instance1);
                }
            };
    }
    
    private static void SyncProperties(PropertyInfo sourceProperty, PropertyInfo targetProperty, object sourceInstance, object targetInstance)
    {
        var sourceValue = sourceProperty.GetValue(sourceInstance);
        var targetValue = targetProperty.GetValue(targetInstance);
    
        if (!sourceValue.Equals(targetValue))
        {
            targetProperty.SetValue(targetInstance, sourceValue);
        }
    }
