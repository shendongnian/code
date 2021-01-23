    public class ParameterDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var pm = item as IParameterModel;
            var fe = container as FrameworkElement;
            if (pm != null && fe != null)
            {
                var dt = fe.TryFindResource("ParameterModel" + pm.Type.Name) as DataTemplate; // ParameterModelBoolean, ParameterModelString, ParameterModelInt32, etc...
                if (dt != null)
                    return dt;
            }
            return base.SelectTemplate(item, container);
        }
    }
