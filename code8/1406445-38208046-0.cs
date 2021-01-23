    public class DataGridRowHeader : System.Windows.Controls.Primitives.DataGridRowHeader
    {
        protected override void OnClick()
        {
            if (Mouse.Captured == this)
            {
                base.ReleaseMouseCapture();
            }
            DataGrid dataGridOwner = GetPropertyValue<DataGrid>(this, "DataGridOwner");
            DataGridRow parentRow = GetPropertyValue<DataGridRow>(this, "ParentRow");
                
            if (dataGridOwner != null && parentRow != null)
            {
                Execute(dataGridOwner, "HandleSelectionForRowHeaderAndDetailsInput", parentRow, false);
            }
        }
    
        private static T GetPropertyValue<T>(object owner, string propertyName) where T : class
        {
            Type ownerType = owner.GetType();
            PropertyInfo propertyInfo = ownerType.GetProperty(propertyName, 
                BindingFlags.Instance | BindingFlags.NonPublic);
    
            while (propertyInfo == null)
            {
                ownerType = ownerType.BaseType;
                propertyInfo = ownerType.GetProperty(propertyName,
                    BindingFlags.Instance | BindingFlags.NonPublic);
            }
    
            return propertyInfo.GetValue(owner, null) as T;
        }
    
        private static void Execute(object owner, string methodName, params object[] parameters)
        {
            Type ownerType = owner.GetType();
            MethodInfo methodInfo = ownerType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
    
            while (methodInfo == null)
            {
                ownerType = ownerType.BaseType;
                methodInfo = ownerType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            }
            methodInfo.Invoke(owner, parameters);
        }
    }
