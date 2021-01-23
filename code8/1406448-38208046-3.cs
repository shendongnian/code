    public class DataGridRowHeader : System.Windows.Controls.Primitives.DataGridRowHeader
    {
        protected override void OnClick()
        {
            if (Mouse.Captured == this)
            {
                base.ReleaseMouseCapture();
            }
            DataGrid dataGridOwner = ReflectionHelper.GetPropertyValue<DataGrid>(this, "DataGridOwner");
            DataGridRow parentRow = ReflectionHelper.GetPropertyValue<DataGridRow>(this, "ParentRow");
                
            if (dataGridOwner != null && parentRow != null)
            {
                ReflectionHelper.Execute(dataGridOwner, "HandleSelectionForRowHeaderAndDetailsInput", parentRow, false);
            }
        }        
    }
