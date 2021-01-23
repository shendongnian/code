    public static class BindableComponentExtensions
    {
        public static void Bind<T>(this IBindableComponent component, T value, Expression<Func<object>> controlProperty, Expression<Func<T, object>> modelProperty)
            where T : INotifyPropertyChanged
        {
            component.DataBindings.Add(new Binding(
                StringExtensions.PropertyName(controlProperty),
                value,
                StringExtensions.PropertyName(modelProperty),
                true,
                DataSourceUpdateMode.OnPropertyChanged));
        }
        public static void Bind<TComponent, T>(this TComponent component, T value,
            Expression<Func<TComponent, object>> controlProperty, Expression<Func<T, object>> modelProperty)
            where TComponent : IBindableComponent
            where T : INotifyPropertyChanged
        {
            component.DataBindings.Add(new Binding(
                StringExtensions.PropertyName(controlProperty),
                value,
                StringExtensions.PropertyName(modelProperty),
                true,
                DataSourceUpdateMode.OnPropertyChanged));
        }
        public static void OneWayBind<TComponent, T>(
            this TComponent component, T value, 
            Expression<Func<TComponent, object>> controlProperty, 
            Expression<Func<T, object>> modelProperty
        )
            where TComponent : IBindableComponent
            where T : INotifyPropertyChanged
        {
            component.DataBindings.Add(new Binding(
                StringExtensions.PropertyName(controlProperty),
                value,
                StringExtensions.PropertyName(modelProperty),
                true,
                DataSourceUpdateMode.Never));
        }
    }
