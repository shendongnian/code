    public class MyTemplateColumn : DataGridTemplateColumn
    {
        protected override System.Windows.FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            //Create instance of your behavior
            MyDataGridBehavior b = new MyDataGridBehavior();
           
            //Attach behavior to the DataGridCell
            System.Windows.Interactivity.Interaction.GetBehaviors(cell).Add(b);
            
            return base.GenerateElement(cell, dataItem);
        }
    }
